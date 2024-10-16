using AutoMapper;
using LocalizationLanguage;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Data.Entities.Identity;



namespace SchoolProject.Core.Features.ApplicationUser.Commands.Handlers
{
    public class UserCommandHandler :ApiResponseHandler, IRequestHandler<AddUserCommand, ApiResponse<string>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<UserCommandHandler> _localizer;

        public UserCommandHandler(IMapper mapper,UserManager<User> userManager,IStringLocalizer<UserCommandHandler> localizer):base(localizer)
        {
            _mapper = mapper;
            this._userManager = userManager;
            this._localizer = localizer;
        }
        //add user
        public async Task<ApiResponse<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {

            // user  or email exist
            var username = await _userManager.FindByNameAsync(request.UserName);
            if (username != null) { return Failed<string>(_localizer[ShareResourcesKey.IsExist]); }

            var email = await _userManager.FindByEmailAsync(request.Email);
            if (email != null) { return Failed<string>(_localizer[ShareResourcesKey.IsExist]); }
            //mapping
            var user=_mapper.Map<User>(request);
            //Create -add
            var result =await _userManager.CreateAsync(user, request.Password);

            //Filed
            if (!result.Succeeded)
                return Failed<string>(_localizer[ShareResourcesKey.Failed]);

            // add user to role
            await _userManager.AddToRoleAsync(user, "Basic");
           //Success
            return Created<string>(_localizer[ShareResourcesKey.Created]);
 
        }

        //ُEdit User

        //Delete User

        //Details User
    }
}
