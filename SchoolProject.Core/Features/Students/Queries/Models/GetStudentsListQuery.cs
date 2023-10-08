﻿using MediatR;
using SchoolProject.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetStudentsListQuery : IRequest<IEnumerable<Student>>
    {

    }
}
