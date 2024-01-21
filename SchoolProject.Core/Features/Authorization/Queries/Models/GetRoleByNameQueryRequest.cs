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
    public class GetRoleByNameQueryRequest : IRequest<Response<GetRoleByNameQueryResponse>>
    {
        public string? SearchName { get; set; }
    }
}
