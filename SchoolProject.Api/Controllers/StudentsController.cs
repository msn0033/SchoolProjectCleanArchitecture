using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Students.Queries.Models;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("/Student/List")]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await _mediator.Send(new StudentsListQuery());
            return Ok(response);
        }

        [HttpGet("/GetById/{id}")]
        public async Task<IActionResult> GetStudnetById(int id)
        {
            var responsestudent = await _mediator.Send(new StudentByIdQuery { id = id });
            if (responsestudent == null) NotFound(responsestudent);
            return Ok(responsestudent);


        }
    }
}
