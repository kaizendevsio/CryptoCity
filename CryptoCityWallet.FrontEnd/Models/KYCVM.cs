using System;

namespace CryptoCityWallet.FrontEnd.Models
{
    public class KycVM : UserVM
    {


        public string Username { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string AddressLineOne { get; set; }

        public string AddressLineTwo { get; set; }
        public int ID { get; set; }
        public string CityOrTown { get; set; }
        public string StateOrProvince { get; set; }
        public int PostalCode { get; set; }
        public int Contact { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string DirectSponsorID { get; set; }
        public string BinarySponsorID { get; set; }
        public int BinaryPosition { get; set; }
    
    public string Currency { get; set; }
    public int Zip { get; set; }
        public byte[] Photo { get; set; }

    }
}
