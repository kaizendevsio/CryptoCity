using System;
using System.Collections.Generic;

namespace CryptoCityWallet.Entities.DTO
{
    public partial class TblBusinessPackage
    {
        public TblBusinessPackage()
        {
            TblIncomeDistribution = new HashSet<TblIncomeDistribution>();
            TblUserBusinessPackage = new HashSet<TblUserBusinessPackage>();
        }

        public long Id { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? LastChanged { get; set; }
        public string PackageName { get; set; }
        public long? PackageTypeId { get; set; }
        public string PackageDescription { get; set; }
        public string PackageCode { get; set; }
        public decimal? ValueFrom { get; set; }
        public decimal? ValueTo { get; set; }
        public long? CurrencyId { get; set; }

        public virtual TblCurrency Currency { get; set; }
        public virtual TblBusinessPackageType PackageType { get; set; }
        public virtual ICollection<TblIncomeDistribution> TblIncomeDistribution { get; set; }
        public virtual ICollection<TblUserBusinessPackage> TblUserBusinessPackage { get; set; }
    }
}
