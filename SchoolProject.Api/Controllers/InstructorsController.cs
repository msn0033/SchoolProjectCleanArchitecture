using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;

using SchoolProject.Core.Features.Instructors.Queries.Get_InstructorByFunctionTable;


namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : AppControllersBase
    {
        [HttpGet]
        public async Task<IActionResult> GetSalary()
        {
            return null;

        }

        [HttpGet("getTable")]
        public async Task<IActionResult> GetTable()
        {
            var x = await _mediator.Send(new Get_InstructorByIdQuery());
            return Ok(x);
            //return Ok("ddd");

        }
    }
}
