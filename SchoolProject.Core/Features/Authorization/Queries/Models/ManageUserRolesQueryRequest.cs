using MediatR;
using SchoolProject.Core.Features.Authorization.Queries.Responses;
using SchoolProject.Helper.ResponseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Queries.Models
{
    public class ManageUserRolesQueryRequest : IRequest<Response<ManageUserRolesQueryResponse>>
    {
        public int UserId { get; set; }
    }
}
