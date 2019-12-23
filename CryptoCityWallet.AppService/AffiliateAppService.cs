using CryptoCityWallet.Entities.DTO;
using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.Enums;
using CryptoCityWallet.DataAccessLayer;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
namespace CryptoCityWallet.AppService
{
   public class AffiliateAppService
    {
        public AffiliateMapBO GetAffiliateLink(AffiliateMapBO affiliateMapBO)
        {
            UserAppService userAppService = new UserAppService();

            var _bsi = userAppService.Get(new TblUserAuth { UserName = affiliateMapBO.BinarySponsorID });
            var _dsi = userAppService.Get(new TblUserAuth { UserName = affiliateMapBO.DirectSponsorID });
            affiliateMapBO.BinarySponsorID = _bsi != null ? _bsi.Uid : throw new ArgumentException("Binary sponsor is invalid");
            affiliateMapBO.DirectSponsorID = _dsi != null ? _dsi.Uid : throw new ArgumentException("Introducer is invalid");

            return affiliateMapBO;
        }
    }
}
