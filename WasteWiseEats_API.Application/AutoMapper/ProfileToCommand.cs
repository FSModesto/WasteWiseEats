using AutoMapper;
using WasteWiseEats_API.Application.ViewModels.Requests.DonationCenter;
using WasteWiseEats_API.Application.ViewModels.Requests.DonationProposal;
using WasteWiseEats_API.Application.ViewModels.Requests.Employee;
using WasteWiseEats_API.Application.ViewModels.Requests.Food;
using WasteWiseEats_API.Application.ViewModels.Requests.Restaurant;
using WasteWiseEats_API.Application.ViewModels.Requests.WasteRegister;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.DonationCenter;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.DonationProposal;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.Employee;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.Restaurant;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.WasteRegister;

namespace WasteWiseEats_API.Application.AutoMapper
{
    public class ProfileToCommand : Profile
    {
        public ProfileToCommand()
        {
            #region DonationCenter

            CreateMap<CreateDonationCenterViewModel, CreateDonationCenterCommand>();
            CreateMap<UpdateDonationCenterViewModel, UpdateDonationCenterCommand>();
            CreateMap<DonationCenterAddressRequestViewModel, DonationCenterAddressSubCommand>();

            #endregion


            #region DonationProposal

            CreateMap<CreateDonationProposalViewModel, CreateDonationProposalCommand>();

            #endregion


            #region Employee

            CreateMap<CreateEmployeeViewModel, CreateEmployeeCommand>();
            CreateMap<UpdateEmployeeViewModel, UpdateEmployeeCommand>();

            #endregion


            #region Restaurant

            CreateMap<CreateRestaurantViewModel, CreateRestaurantCommand>();
            CreateMap<UpdateRestaurantViewModel, UpdateRestaurantCommand>();
            CreateMap<RestaurantAddressRequestViewModel, RestaurantAddressSubCommand>();

            #endregion


            #region WasteRegister

            CreateMap<CreateWasteRegisterViewModel, CreateWasteRegisterCommand>();
            CreateMap<UpdateWasteRegisterViewModel, UpdateWasteRegisterCommand>();

            #endregion

            #region Food

            CreateMap<FoodRequestViewModel, FoodSubCommand>();

            #endregion
        }
    }
}
