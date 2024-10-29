using AutoMapper;
using LocalizationLanguage;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Enums;



namespace SchoolProject.Core.Features.ApplicationUser.Commands.Create
{
    public class CreateUserHandler : ApiResponseHandler, IRequestHandler<CreateUserCommand, ApiResponse<string>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<CreateUserHandler> _localizer;

        public CreateUserHandler(IMapper mapper, UserManager<User> userManager, IStringLocalizer<CreateUserHandler> localizer) : base(localizer)
        {
            _mapper = mapper;
            _userManager = userManager;
            _localizer = localizer;
        }
        //add user
        public async Task<ApiResponse<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            // user  or email exist
            var username = await _userManager.FindByNameAsync(request.UserName);
            if (username != null) { return Failed<string>(_localizer[ShareResourcesKey.IsExist]); }

            var email = await _userManager.FindByEmailAsync(request.Email);
            if (email != null) { return Failed<string>(_localizer[ShareResourcesKey.IsExist]); }
            //mapping
            var user = _mapper.Map<User>(request);
            //Create -add
            var result = await _userManager.CreateAsync(user, request.Password);

            //Filed
            if (!result.Succeeded)
                return Failed<string>(_localizer[ShareResourcesKey.Failed]);

            // add user to role
            await _userManager.AddToRoleAsync(user, RolesEnum.Basic.ToString());
            //Success
            return Created<string>(_localizer[ShareResourcesKey.Created]);

        }

        //ُEdit User

        //Delete User

        //Details User
    }
}
