using AutoMapper;
using LocalizationLanguage;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Helper.Resources;
using SchoolProject.Helper.ResponseHelper;


namespace SchoolProject.Core.Features.ApplicationUser.Commands.Handlers
{
    public class UserCommandHandler :ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>
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
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
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
            var userscount = _userManager.Users.Count();
            if(userscount>=0)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            //Success
            return Created<string>(_localizer[ShareResourcesKey.Created]);
 
        }

        //ُEdit User

        //Delete User

        //Details User
    }
}
