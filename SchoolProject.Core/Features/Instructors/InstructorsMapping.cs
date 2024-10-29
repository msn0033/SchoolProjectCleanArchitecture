using AutoMapper;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Instructors
{
    public class InstructorsMapping:Profile
    {
        public InstructorsMapping()
        {

            // Instructor to Dto
            CreateMap<Instructor, InstructorsDto>()
               .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
        }
    }
    }
