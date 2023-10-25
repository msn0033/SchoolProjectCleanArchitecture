using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using System.Text;

namespace SchoolProject.Api.Controllers
{
  //  [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : AppControllersBase
    {

        [HttpGet("/Departments/List")]
        public  IActionResult GetDepartments()
        {
            var re =new StringBuilder( "test Departments");
            return Ok(re);
        }
        [HttpGet("/Departments/GetById/{id}")]
        public async Task<IActionResult> GetDepartmentByIdAsync(int id)
        {
            var response =await _mediator.Send(new GetDepartmentByIdQuery(id));
            return Ok(response);
        }
    }

  




}
