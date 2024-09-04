using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Filters;
using SchoolProject.Data.AppMetaData;
using SchoolProject.Data.Permission;

namespace SchoolProject.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]

    //[Authorize(Roles = "SuperAdmin")]

    public class StudentsController : AppControllersBase
    {

        [CheckPermission(Permission.Students.View)]
        [Authorize(Roles ="Sales")]
        [HttpGet(PathRoute.StudentsRoute.List)]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await _mediator.Send(new StudentsListQueryRequest());
            return Ok(response);
        }

        [CheckPermission(Permission.Students.View)]
        [Authorize(Policy = "CityFromJeddah")]
        [HttpGet(PathRoute.StudentsRoute.GetById)]
        public async Task<IActionResult> GetStudnetById([FromRoute] int id)
        {
            var responsestudent = await _mediator.Send(new StudentByIdQueryRequest { id = id });
            if (responsestudent == null) NotFound(responsestudent);
            return NewResult(responsestudent!);
        }

        [CheckPermission(Permission.Students.Create+"2")]
        [HttpPost(PathRoute.StudentsRoute.Create)]
        public async Task<IActionResult> CreateStudent([FromBody] AddStudentCommand command)
        {
            var responseaddStudent = await _mediator.Send(command);
            return NewResult(responseaddStudent);

        }

        [Authorize(Roles ="Admin")]
        [HttpPut(PathRoute.StudentsRoute.Edit)]
        public async Task<IActionResult> EditStudent([FromBody] EditStudentCommand editStudent)
        {
            var response = await _mediator.Send(editStudent);
            return NewResult<string>(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete(PathRoute.StudentsRoute.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteStudentCommand(id));
            return NewResult(response);
        }


        [HttpGet(PathRoute.StudentsRoute.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetStudentPaginatedListQueryRequest query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);

        }

    }
}
