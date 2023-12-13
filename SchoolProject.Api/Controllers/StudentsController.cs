using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentsController : AppControllersBase
    {


        [HttpGet(PathRoute.StudentsRoute.List)]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await _mediator.Send(new StudentsListQuery());
            return Ok(response);
        }

        [HttpGet(PathRoute.StudentsRoute.GetById)]
        public async Task<IActionResult> GetStudnetById([FromRoute] int id)
        {
            var responsestudent = await _mediator.Send(new StudentByIdQuery { id = id });
            if (responsestudent == null) NotFound(responsestudent);
            return NewResult(responsestudent!);
        }

        [HttpPost(PathRoute.StudentsRoute.Create)]
        public async Task<IActionResult> CreateStudent([FromBody] AddStudentCommand command)
        {
            var responseaddStudent = await _mediator.Send(command);
            return NewResult(responseaddStudent);

        }
        [HttpPut(PathRoute.StudentsRoute.Edit)]
        public async Task<IActionResult> EditStudent([FromBody] EditStudentCommand editStudent)
        {
            var response = await _mediator.Send(editStudent);
            return NewResult<string>(response);
        }
        [HttpDelete(PathRoute.StudentsRoute.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteStudentCommand(id));
            return NewResult(response);
        }
        [HttpGet(PathRoute.StudentsRoute.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetStudentPaginatedListQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);

        }

    }
}
