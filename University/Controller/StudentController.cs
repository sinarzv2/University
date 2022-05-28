using Microsoft.AspNetCore.Mvc;
using University.Entities;
using University.Persistent.IRepositories;

namespace University.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var studentList = await _studentRepository.GetAllAsync(cancellationToken);
            return Ok(studentList);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Student student, CancellationToken cancellationToken)
        {
            await _studentRepository.AddAsync(student, cancellationToken);
            await _studentRepository.CommitChanges(cancellationToken);
            return Ok(student.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Student student, CancellationToken cancellationToken)
        {
            await _studentRepository.UpdateAsync(student, cancellationToken);
            await _studentRepository.CommitChanges(cancellationToken);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await _studentRepository.DeleteAsync(id, cancellationToken);
            await _studentRepository.CommitChanges(cancellationToken);
            return Ok();
        }
    }
}
