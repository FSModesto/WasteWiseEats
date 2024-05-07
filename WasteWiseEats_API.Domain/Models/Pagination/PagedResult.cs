using WasteWiseEats_API.Domain.Models.Filters;

namespace WasteWiseEats_API.Domain.Models.Pagination
{
    public class PagedResult<T>
    {
        public PagedResult()
        {
        }

        public PagedResult(PaginationFilter pagedFilter, long totalItens, List<T> results)
        {
            Page = pagedFilter.Page;
            ItensPerPage = pagedFilter.ItemsPerPage;
            TotalItens = totalItens;
            Results = results;

            MaxPages = (int)Math.Ceiling((double)totalItens / pagedFilter.ItemsPerPage);
        }

        public int Page { get; set; }

        public int ItensPerPage { get; set; }

        public long TotalItens { get; set; }

        public int MaxPages { get; set; }

        public List<T> Results { get; set; }
    }
}
