﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.DonationCenter;
using WasteWiseEats_API.Domain.Entities;
using WasteWiseEats_API.Domain.Exceptions;
using WasteWiseEats_API.Domain.Exceptions.Enums;
using WasteWiseEats_API.Domain.Interfaces.Repositories;
using WasteWiseEats_API.Domain.Models;

namespace WasteWiseEats_API.Domain.CommandHandlers
{
    public class DonationCenterCommandHandler : IRequestHandler<CreateDonationCenterCommand, Guid>,
                                            IRequestHandler<UpdateDonationCenterCommand, Guid>,
                                            IRequestHandler<DeleteDonationCenterCommand, Unit>
    {
        private readonly IDonationCenterRepository _repository;

        public DonationCenterCommandHandler(IDonationCenterRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateDonationCenterCommand request, CancellationToken cancellationToken)
        {
            //TODO: Validar pelo User se o UserId já possui DonationCenter e disparar APIException

            DonationCenter donationCenter = new()
            {
                //TODO: Atribuir UserId pelo Bearer retornado com o Role.DonationCenter
                Name = request.Name,
                Owner = request.Owner,
                OwnerDocument = request.OwnerDocument,
                Phone = Phone.RemoveMask(request.Phone),
                Email = request.Email,
                BeginTime = request.BeginTime,
                EndTime = request.EndTime,

                Address = new DonationCenterAddress()
                {
                    Street = request.Address.Street,
                    Number = request.Address.Number,
                    Complement = request.Address.Complement,
                    ZipCode = request.Address.ZipCode,
                    District = request.Address.District,
                    City = request.Address.City,
                    State = request.Address.State,
                }
            };

            await _repository.Create(donationCenter);
            return donationCenter.Id;
        }

        public async Task<Guid> Handle(UpdateDonationCenterCommand request, CancellationToken cancellationToken)
        {
            DonationCenter donationCenter = await ValidateDonationCenter(request.Id);

            donationCenter.Name = request.Name;
            donationCenter.Owner = request.Owner;
            donationCenter.OwnerDocument = request.OwnerDocument;
            donationCenter.Phone = Phone.RemoveMask(request.Phone);
            donationCenter.Email = request.Email;
            donationCenter.BeginTime = request.BeginTime;
            donationCenter.EndTime = request.EndTime;


            donationCenter.Address.Street = request.Address.Street;
            donationCenter.Address.Number = request.Address.Number;
            donationCenter.Address.City = request.Address.City;
            donationCenter.Address.State = request.Address.State;
            donationCenter.Address.ZipCode = request.Address.ZipCode;
            donationCenter.Address.District = request.Address.District;
            donationCenter.Address.Complement = request.Address.Complement;

            await _repository.Update(donationCenter);
            return donationCenter.Id;
        }

        public async Task<Unit> Handle(DeleteDonationCenterCommand request, CancellationToken cancellationToken)
        {
            DonationCenter donationCenter = await ValidateDonationCenter(request.Id);

            await _repository.Delete(donationCenter);

            return Unit.Value;
        }

        private async Task<DonationCenter> ValidateDonationCenter(Guid id)
        {
            DonationCenter donationCenter =
                await _repository.Find(wh => wh.Id == id, query => query.Include(entity => entity.Address));

            if (donationCenter is null)
                throw new ApiException(EApiException.DonationCenterNotFound);

            return donationCenter;
        }
    }
}
