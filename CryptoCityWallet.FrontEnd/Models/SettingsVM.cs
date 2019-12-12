using System;

namespace CryptoCityWallet.FrontEnd.Models
{
    public class SettingsVM
    {



        public string Username { get; set; }

        public string Email { get; set; }

        public string Currency { get; set; }


        public string Language { get; set; }

        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string City { get; set; }

        public int Zip { get; set; }
        public byte[] Photo { get; set; }

    }
}
