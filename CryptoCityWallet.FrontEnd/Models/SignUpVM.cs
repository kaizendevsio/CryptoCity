using System;

namespace CryptoCityWallet.FrontEnd.Models
{
    public class SignUpVM
    {
        public string Username { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string Address1 { get; set; }

        public string Address2 { get; set; }
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
        public byte Photo { get; set; }

    }
}
