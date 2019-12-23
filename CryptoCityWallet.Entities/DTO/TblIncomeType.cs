using System;
using System.Collections.Generic;

namespace CryptoCityWallet.Entities.DTO
{
    public partial class TblIncomeType
    {
        public TblIncomeType()
        {
            TblIncomeDistribution = new HashSet<TblIncomeDistribution>();
            TblUserIncomePartition = new HashSet<TblUserIncomePartition>();
        }

        public long Id { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? LastChanged { get; set; }
        public string IncomeTypeCode { get; set; }
        public string IncomeTypeName { get; set; }
        public string IncomeShortName { get; set; }
        public string IncomeTypeDescription { get; set; }
        public decimal? IncomePercentage { get; set; }
        public bool? IsReward { get; set; }

        public virtual ICollection<TblIncomeDistribution> TblIncomeDistribution { get; set; }
        public virtual ICollection<TblUserIncomePartition> TblUserIncomePartition { get; set; }
    }
}
