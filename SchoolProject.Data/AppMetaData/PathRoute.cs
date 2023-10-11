﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.AppMetaData
{
    public static class PathRoute
    {
        public const string id = "{id}";
        public const string root = "Api";
        public const string Version = "V1";
        public const string Rule = root + "/" + Version +"/";
        public static class StudentsRoute
        {
            public const string prefix = Rule + "students";
            public const string List = prefix + "/List";
            public const string GetById = prefix+"/GetById/"+id;
            public const string Create = prefix + "/Create";
        }

    }
}
