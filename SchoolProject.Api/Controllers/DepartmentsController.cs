using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Students.Queries.Models;
using System.Text;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {

        [HttpGet("/Departments/List")]
        public  IActionResult GetDepartments()
        {
            var re =new StringBuilder( "test Departments");
            return Ok(re);
        }
    }

  




}
