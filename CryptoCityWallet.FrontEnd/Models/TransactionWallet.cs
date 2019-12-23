using System;

namespace CryptoCityWallet.FrontEnd.Models
{
    public class TransactionWallet: UserVM
    {
        public DateTime DateTransaction { get; set; }
        public double UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double Amount { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string TxID { get; set; }
        public string Status { get; set; }

        public string Content { get; set; }
        public string Currency { get; set; }









    }
}
