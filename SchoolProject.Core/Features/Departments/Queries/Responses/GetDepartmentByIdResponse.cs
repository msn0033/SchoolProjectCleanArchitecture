﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Departments.Queries.Responses
{
    public class GetDepartmentByIdResponse
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? NameManger { get; set; }
        public List<StudentResponse>? StudentList { get; set; }
        public List<SubjectResponse> ?SubjecttList { get; set; }
        public List<InstructorResponse> ?InstructorList { get; set; }

    }

    public class StudentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class SubjectResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class InstructorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
