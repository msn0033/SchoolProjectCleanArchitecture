using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Core.Base.PaginatedList;
using SchoolProject.Data.Entities.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.ApplicationUser.Queries.GetUsersPaginatedList
{
    public class GetUsersPaginatedListHandler : ApiResponseHandler,
        IRequestHandler<GetUsersPaginatedListQuery, ApiResponse<PaginatedList<GetUsersPaginatedListResponse>>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<GetUsersPaginatedListHandler> _localizer;
        private readonly IMapper _mapper;

        public GetUsersPaginatedListHandler(UserManager<User> userManager, IStringLocalizer<GetUsersPaginatedListHandler> localizer, IMapper mapper) : base(localizer)
        {
            _userManager = userManager;
            _localizer = localizer;
            _mapper = mapper;
        }


        //Get-users-paginated
        public async Task<ApiResponse<PaginatedList<GetUsersPaginatedListResponse>>> Handle(GetUsersPaginatedListQuery request, CancellationToken cancellationToken)
        {
            //query Queryable
            var users = _userManager.Users.AsQueryable();

            //mapper & Paginated
            var result = await _mapper.ProjectTo<GetUsersPaginatedListResponse>(users)
                                    .ToPaginatedListAsync(request.pageNumber, request.pageSize);

            return Success(result);

        }
    }
}
