using MediatR;
using WasteWiseEats_API.Application.ViewModels.Requests.DonationCenter;
using WasteWiseEats_API.Application.ViewModels.Responses.Base;
using WasteWiseEats_API.Application.ViewModels.Responses.DonationCenter;
using WasteWiseEats_API.Domain.Models.Interfaces;

namespace WasteWiseEats_API.Application.AppServices.Interfaces
{
    public interface IDonationCenterAppService
    {
        Task<IResponse<Guid>> Create(CreateDonationCenterViewModel viewModel);

        Task<IResponse<Guid>> Update(UpdateDonationCenterViewModel viewModel);

        Task<IResponse> Delete(Guid id);

        Task<IResponse<GetDonationCenterViewModel>> Get(Guid id);

        Task<IResponse<IEnumerable<GetMinifiedDonationCentersViewModel>>> GetAll(string state, TimeSpan workingTime);
    }
}
