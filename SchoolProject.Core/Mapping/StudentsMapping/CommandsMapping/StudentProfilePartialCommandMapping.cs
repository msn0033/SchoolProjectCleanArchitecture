﻿using AutoMapper;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.StudentsMapping
{
    public partial class StudentProfile : Profile
    {
       public void addStudentCommandMapping()
        {
            CreateMap<StudentCommandRequest, Student>();
        }
    }
}
