using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.DepartmentsMapping
{
    public partial class  DepartmentsProfile:Profile
    {
        public DepartmentsProfile()
        {
            DepartmentsDetailsQueryMapping();
        }
    }
}
