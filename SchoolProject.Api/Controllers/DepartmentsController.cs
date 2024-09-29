using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;
using System.Net;
using System.Text;

namespace SchoolProject.Api.Controllers
{
  //  [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentsController : AppControllersBase
    {

        [HttpGet(PathRoute.DepartmentRoute.List)]
        public  IActionResult GetDepartments()
        {
        
            var re =new StringBuilder( "test Departments");
            return Ok(re);
        }
        
        [HttpGet(PathRoute.DepartmentRoute.GetById)]
        public async Task<IActionResult> GetDepartmentByIdAsync([FromQuery]GetDepartmentByIdQuery query)
        {
            var response =await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet(PathRoute.DepartmentRoute.GetViewDepartmentwithStudentCountView)]
        public async Task<IActionResult> GetViewDepartmentwithStudentCountView()
        {
           var response=await  _mediator.Send(new GetDepartmentStudentCountViewQuery());
            return Ok(response);
        }
        [HttpGet(PathRoute.DepartmentRoute.GetDepartment_ById_StudentCountProc)]
        public async Task<IActionResult> GetDepartment_ById_StudentCountProc( [FromRoute]GetDepartment_ById_StudentCountProcQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }

  




}
