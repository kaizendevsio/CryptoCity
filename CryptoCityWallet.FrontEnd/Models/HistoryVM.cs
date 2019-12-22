using System;

namespace CryptoCityWallet.FrontEnd.Models
{
    public class HistoryVM : UserVM
    {
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public double In { get; set; }
        public double Out { get; set; }
        
        public double Balance { get; set; }
    }
}
