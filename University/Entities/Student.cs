using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using University.Common;

namespace University.Entities
{
    public class Student
    {
        public Student()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Range(1,100)]
        public int Age { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly BirthDate { get; set; }
    }
}
