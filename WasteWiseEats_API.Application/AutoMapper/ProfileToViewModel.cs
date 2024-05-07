using AutoMapper;
using WasteWiseEats_API.Application.ViewModels.Responses.DonationCenter;
using WasteWiseEats_API.Application.ViewModels.Responses.DonationProposal;
using WasteWiseEats_API.Application.ViewModels.Responses.Employee;
using WasteWiseEats_API.Application.ViewModels.Responses.Food;
using WasteWiseEats_API.Application.ViewModels.Responses.Pagination;
using WasteWiseEats_API.Application.ViewModels.Responses.Restaurant;
using WasteWiseEats_API.Application.ViewModels.Responses.SecurityProfiles;
using WasteWiseEats_API.Application.ViewModels.Responses.WasteRegister;
using WasteWiseEats_API.Domain.Entities;
using WasteWiseEats_API.Domain.Models.Pagination;

namespace WasteWiseEats_API.Application.AutoMapper
{
    public class ProfileToViewModel : Profile
    {
        public ProfileToViewModel()
        {
            #region DonationCenter

            CreateMap<DonationCenterAddress, DonationCenterAddressResponseViewModel>();
            CreateMap<DonationCenter, GetDonationCenterViewModel>();
            CreateMap<DonationCenter, GetMinifiedDonationCentersViewModel>();
            CreateMap<PagedResult<DonationCenter>, PagedResultViewModel<GetMinifiedDonationCentersViewModel>>();

            #endregion


            #region DonationProposal

            CreateMap<DonationProposal, GetDonationProposalViewModel>();
            CreateMap<DonationProposal, GetMinifiedDonationProposalsViewModel>();
            CreateMap<PagedResult<DonationProposal>, PagedResultViewModel<GetMinifiedDonationProposalsViewModel>>();

            #endregion


            #region Employee

            CreateMap<Employee, GetEmployeeViewModel>();
            CreateMap<Employee, GetMinifiedEmployeesViewModel>();
            CreateMap<PagedResult<Employee>, PagedResultViewModel<GetMinifiedEmployeesViewModel>>();

            #endregion


            #region Restaurant

            CreateMap<Restaurant, GetRestaurantAddressViewModel>();
            CreateMap<RestaurantAddress, GetRestaurantAddressViewModel>();

            #endregion


            #region WasteRegister

            CreateMap<WasteRegister, GetMinifiedWasteRegistersViewModel>();
            CreateMap<WasteRegister, GetWasteRegisterViewModel>();
            CreateMap<PagedResult<WasteRegister>, PagedResultViewModel<GetMinifiedWasteRegistersViewModel>>();

            #endregion

            #region Food

            CreateMap<Food, FoodResponseViewModel>();

            #endregion

            #region SecurityProfile

            CreateMap<SecurityProfile, SecurityProfileViewModel>();

            #endregion
        }
    }
}
