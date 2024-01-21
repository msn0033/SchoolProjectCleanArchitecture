using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.ApplicationUser.Queries.Models;
using SchoolProject.Core.Features.ApplicationUser.Queries.Responses;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Helper.Extension;
using SchoolProject.Helper.ResponseHelper;
using SchoolProject.Helper.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.ApplicationUser.Queries.Handlers
{
    public class UserQueryHandler : ResponseHandler, 
        IRequestHandler<GetUsersPaginatedListQuery,Response<PaginatedResult<GetUsersPaginatedListResponse>>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<UserQueryHandler> _localizer;
        private readonly IMapper _mapper;

        public UserQueryHandler( UserManager<User> userManager,IStringLocalizer<UserQueryHandler> localizer ,IMapper mapper):base(localizer)
        {
            this._userManager = userManager;
            this._localizer = localizer;
            this._mapper = mapper;
        }

       
        //Get-users-paginated
        public async Task<Response< PaginatedResult<GetUsersPaginatedListResponse>>> Handle(GetUsersPaginatedListQuery request, CancellationToken cancellationToken)
        {
            //query Queryable
            var users = _userManager.Users.AsQueryable();

            //mapper & Paginated
            var result=await _mapper.ProjectTo<GetUsersPaginatedListResponse>(users)
                                    .ToPaginatedListAsync(request.pageNumber, request.pageSize);
          
            return Success(result);

        }
    }
}
