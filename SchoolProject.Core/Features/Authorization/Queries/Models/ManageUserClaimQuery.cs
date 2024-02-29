using MediatR;
using SchoolProject.Data.Result;
using SchoolProject.Helper.ResponseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Queries.Models
{
    public class ManageUserClaimQuery:IRequest<Response<ManageUserClaimsResult>>
    {
        public int UserId { get; set; }
    }
}
