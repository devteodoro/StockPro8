﻿namespace StockPro.ViewModels.Address
{
    public class CreateAddressViewModel
    {
        public required string ZipCode { get; set; } 

        public string? Country { get; set; }

        public string? State { get; set; }

        public string? City { get; set; }

        public string? Street { get; set; }

        public string? Number { get; set; }

        public string? Complement { get; set; }
    }
}
