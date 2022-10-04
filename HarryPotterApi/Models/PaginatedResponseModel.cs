namespace HarryPotterApi.Models
{
    public class PaginatedResponseModel<T>
    {
        public int TotalPages { get; }
        public int CurrentPage { get; }
        public int Items => Data.Count();
        public IEnumerable<T> Data { get; }

        public PaginatedResponseModel(int totalPages, int currentPage, IEnumerable<T> data)
        {
            TotalPages = totalPages;
            CurrentPage = currentPage;
            Data = data;
        }
    }
}
