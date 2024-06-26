﻿namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.Address
{
    public abstract class AddressSubCommand
    {
        public Guid Id { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Complement { get; set; }

        public string District { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }
    }
}
