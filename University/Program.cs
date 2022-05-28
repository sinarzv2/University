using Marten;
using Marten.Services.Json;
using University.Persistent.IRepositories;
using University.Persistent.Repositories;
using Weasel.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//builder.Services.AddDbContext<UniversityContext>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString("UniversityContext")));

builder.Services.AddMarten(BuildStoreOptions()).UseLightweightSessions();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.Run();


StoreOptions BuildStoreOptions()
{
    var connectionString = builder.Configuration.GetConnectionString("UniversityContext");
    var storeOptions = new StoreOptions();
    storeOptions.Connection(connectionString);
    storeOptions.AutoCreateSchemaObjects = AutoCreate.All;
    storeOptions.UseDefaultSerialization(serializerType:SerializerType.SystemTextJson);
    return storeOptions;
}