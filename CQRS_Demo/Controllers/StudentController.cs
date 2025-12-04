using Commands;
using CreateStudent;
using GetStudentById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Queries;

namespace API.Controllers
{
    public class StudentController : Controller
    {
        private readonly ISender _sender;
        public StudentController(ISender sender)
        {
            _sender = sender;
        }
        [HttpGet("Get-All-Students")]
        public async Task<IActionResult> StudentList()
        {
            var response = await _sender.Send(new GetStudentsListQuery());
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("create-student")]
        public async Task<IActionResult> CreateStudent(CreateStudentCommand command)
        {
            var response = await _sender.Send(command);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpGet("Get-student-Id")]
        public async Task<IActionResult> StudentById(Guid studentId)
        {
            var response = await _sender.Send(new GetStudentByIdQuery(studentId));
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPut("Update-student")]
        public async Task<IActionResult> UpdateStudent(UpdateStudentCommand command)
        {
            var response = await _sender.Send(command);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }

            [HttpDelete("Delete-student-Id")]
        public async Task<IActionResult> DeleteStudentById(Guid studentId)
        {
            var response = await _sender.Send(new DeleteStudentCommand(studentId));
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
