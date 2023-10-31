using Microsoft.EntityFrameworkCore;
using SchoolProject.Helper.Wrappers;

namespace SchoolProject.Helper.Extension
{
    public static class QueryableExtensions_ToPaginatedListAsync
    {
        public async static Task<PaginatedResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize) where T : class
        {
            if (source == null) throw new ArgumentNullException("Empty");
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;

            int totalcount = await source.AsNoTracking().CountAsync();
            if (totalcount == 0) return PaginatedResult<T>.Success(new List<T>(), totalcount, pageNumber, pageSize);
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            var item = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return PaginatedResult<T>.Success(item, totalcount, pageNumber, pageSize);

        }
    }
}
