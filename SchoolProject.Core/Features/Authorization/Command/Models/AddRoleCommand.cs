﻿using MediatR;
using SchoolProject.Helper.ResponseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Command.Models
{
    public class AddRoleCommand:IRequest<Response<string>>
    {
        public required string Name { get; set; } 
    }
}
