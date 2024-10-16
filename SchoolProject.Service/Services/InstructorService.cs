using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Infrustructure.Context;
using SchoolProject.Infrustructure.GenericRepository;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SchoolProject.Service.Services
{
    public class InstructorService : IInstructorService
    {

  



        /*

         // table function         
            Create function Get_Instructor_Data()
            returns @Instrutors Table(Id int,NameAr nvarchar(100),NameEn nvarchar(100))
            as
            begin
            Insert into @Instrutors
            Select inst.Id , inst.NameAr , inst.NameEn from dbo.Instructors as inst
            return 
            end
            select * from Get_Instructor_Data()
                     * */

    }
}
