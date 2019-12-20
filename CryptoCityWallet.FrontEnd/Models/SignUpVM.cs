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
        public string DirectSponsorID { get; set; }
        public string BinarySponsorID { get; set; }
        public int BinaryPosition { get; set; }

    }
}
