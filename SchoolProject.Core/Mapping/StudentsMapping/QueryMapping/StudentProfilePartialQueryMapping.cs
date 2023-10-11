﻿using Microsoft.Identity.Client;
using SchoolProject.Core.Features.Students.Queries.Responses;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.StudentsMapping
{
    public partial class StudentProfile
    {
       public void GetStudentMapping()
        {
            CreateMap<Student, StudentsQueryResponse>()
               .ForMember(des => des.DepartmentName, op => op.MapFrom(src => src.Department.Name));
        }
    }
}
