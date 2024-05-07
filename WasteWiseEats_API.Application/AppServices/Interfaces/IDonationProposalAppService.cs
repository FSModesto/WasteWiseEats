using WasteWiseEats_API.Application.ViewModels.Requests.DonationProposal;
using WasteWiseEats_API.Application.ViewModels.Requests.Pagination;
using WasteWiseEats_API.Application.ViewModels.Responses.DonationProposal;
using WasteWiseEats_API.Application.ViewModels.Responses.Pagination;
using WasteWiseEats_API.Domain.Models.Interfaces;

namespace WasteWiseEats_API.Application.AppServices.Interfaces
{
    public interface IDonationProposalAppService
    {
        Task<IResponse<Guid>> Create(CreateDonationProposalViewModel viewModel);

        Task<IResponse> Accept(Guid id);

        Task<IResponse> Delete(Guid id);

        Task<IResponse<GetDonationProposalViewModel>> Get(Guid id);

        Task<IResponse<PagedResultViewModel<GetMinifiedDonationProposalsViewModel>>> GetAll(DonationProposalFilterViewModel viewModel);
    }
}
