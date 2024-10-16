﻿using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrustructure.GenericRepository
{
    public interface IGenericRepositoryAsync<T> where T:class
    {
        IQueryable<T> GetTableNoTracking();
        IQueryable<T> GetTableAsTracking();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task DeleteRangeAsync(ICollection<T> entities);
        Task SaveChangesAsync();
        IDbContextTransaction BeginTransaction();
        void Commit();
        void RollBack();
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);
        Task DeleteAsync(T entity);
    }
}
