using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.DataAccess;
using University.Entities;

namespace University.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly UniversityContext _context;

        public StudentController(UniversityContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var studentList = await _context.Students.ToListAsync(cancellationToken);
            return Ok(studentList);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Student student, CancellationToken cancellationToken)
        {
            await _context.Students.AddAsync(student,cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Ok(student.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Student student, CancellationToken cancellationToken)
        {
            _context.Students.Attach(student);
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync(cancellationToken);
            return Ok();
        }
    }
}
