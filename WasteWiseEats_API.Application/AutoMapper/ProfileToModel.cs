using AutoMapper;
using WasteWiseEats_API.Application.ViewModels.Requests.Dashboard;
using WasteWiseEats_API.Application.ViewModels.Requests.Pagination;
using WasteWiseEats_API.Domain.Models.Filters;

namespace WasteWiseEats_API.Application.AutoMapper
{
    public class ProfileToModel : Profile
    {
        public ProfileToModel()
        {
            #region Pagination

            CreateMap<PaginationFilterViewModel, PaginationFilter>();

            #endregion

            #region Dashboard

            CreateMap<DashboardFilterViewModel, DashboardFilter>();

            #endregion
        }
    }
}
