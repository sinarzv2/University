using Microsoft.AspNetCore.Mvc;
using University.Entities;
using University.Persistent;
using University.Persistent.IRepositories;

namespace University.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public StudentController( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var studentList = await _unitOfWork.StudentRepository.GetAllAsync(cancellationToken);
            return Ok(studentList);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Student student, CancellationToken cancellationToken)
        {
            await _unitOfWork.StudentRepository.AddAsync(student, cancellationToken);
            await _unitOfWork.CommitChanges(cancellationToken);
            return Ok(student.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Student student, CancellationToken cancellationToken)
        {
            await _unitOfWork.StudentRepository.UpdateAsync(student, cancellationToken);
            await _unitOfWork.CommitChanges(cancellationToken);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await _unitOfWork.StudentRepository.DeleteAsync(id, cancellationToken);
            await _unitOfWork.CommitChanges(cancellationToken);
            return Ok();
        }
    }
}
