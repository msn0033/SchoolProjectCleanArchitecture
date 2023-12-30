using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrustructure.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrustructure.Interface
{
    public interface IRefreshTokenRepository:IGenericRepositoryAsync<UserRefreshToken>
    {

    }
}
