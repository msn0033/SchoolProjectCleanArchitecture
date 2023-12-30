using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrustructure.Context;
using SchoolProject.Infrustructure.GenericRepository;
using SchoolProject.Infrustructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrustructure.Repositories
{
    public class RefreshTokenRepository : GenericRepositoryAsync<UserRefreshToken>,IRefreshTokenRepository
    {
        private readonly DbSet<UserRefreshToken> _userRefreshTokens;
        public RefreshTokenRepository(AppDbContext dbContext) : base(dbContext)
        {
            _userRefreshTokens = dbContext.UserRefreshTokens;
        }
    }
}
