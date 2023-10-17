namespace SchoolProject.Helper.Wrappers
{
    public class PaginatedResult<T>
    {
        public List<T> Data { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public object? Meta { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool NextPage => CurrentPage < TotalPages;
        public List<string> Messages { get; set; } = new();
        public bool Succeeded { get; set; }

        public PaginatedResult(List<T> data)
        {
            Data = data;
        }

        public PaginatedResult(bool succeeded, List<T> data = default!, List<string> Message = null!, int currentPage = 1, int pageSize = 10, int totalCount = 0, int totalPage = 1)
        {
            Data = data;
            CurrentPage = currentPage;
            Succeeded = succeeded;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            TotalCount = totalCount;



        }
        public static PaginatedResult<T> Success(List<T> data, int totalcount, int currentpage, int pagesize)
        {
            return new(true, data, null!, currentpage, pagesize, totalcount);
        }
    }
}
