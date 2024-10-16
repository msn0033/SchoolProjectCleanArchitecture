﻿using MediatR;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.GetAllStudents
{
    public class GetAllStudentsQuery : IRequest<ApiResponse<List<StudentResponse>>>
    {

    }
}
