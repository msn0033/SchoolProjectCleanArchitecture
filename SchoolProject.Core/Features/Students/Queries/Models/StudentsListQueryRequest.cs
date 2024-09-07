using MediatR;
using SchoolProject.Core.Features.Students.Queries.Responses;
using SchoolProject.Data.Entities;
using SchoolProject.Helper.ResponseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class StudentsListQueryRequest : IRequest<Response<IEnumerable<GetStudentsListQueryResponse>>>
    {
       
    }
}
