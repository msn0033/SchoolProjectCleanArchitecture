using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;

using SchoolProject.Data.Entities.Identity;
using SchoolProject.Helper.Resources;
using SchoolProject.Helper.ResponseHelper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Handlers
{
    public class UserCommandHandler :ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserCommandHandler(IMapper mapper,UserManager<User> userManager,IStringLocalizer<ShareResources> localizer):base(localizer)
        {
            _mapper = mapper;
            this._userManager = userManager;
        }
        //add user
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {

            // user  or email exist
            var user = await _userManager.FindByNameAsync(request.UserName);
           // if (user == null) { return }
                //return exist
           //mapping


            //Create -add
               //Success
                 //mesage
               //Filed
                  //message
            throw new NotImplementedException();
        }
    }
}
