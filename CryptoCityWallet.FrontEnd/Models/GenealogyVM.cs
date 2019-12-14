using System;

namespace CryptoCityWallet.FrontEnd.Models
{
    public class GenealogyVM : UserVM
    {
        public double TotalInvestment { get; set; }
        public int DirectPartners { get; set; }
        public decimal DirectVolume { get; set; }
        public decimal TotalGroupVolume { get; set; }
    }
}
