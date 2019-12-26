using System;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using CryptoCityWallet.Entities.DTO;
using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.Enums;
using CryptoCityWallet.DataAccessLayer;
using System.Collections.Generic;

namespace CryptoCityWallet.DataAccessLayer
{
   public class ExternalRecordsRepository
    {
        public decimal GetInvestmentSum(TblUserAuth userAuth, dbWorldCCityContext db)
        {
            decimal? InvestmentSum = db.VOrder.Where(i => i.UserAuthId == userAuth.Id).Sum(item => item.Amount);
            return InvestmentSum == 0 ? 0 : (decimal)InvestmentSum;
        }

        public int GetDirectPartners(TblUserAuth userAuth,dbWorldCCityContext db)
        {
            int Dp = db.VMember.Count(item => item.SponsorUserId == userAuth.Id);
            return Dp;
        }

        public bool CreateUserVolume(TblUserAuth userAuth, dbWorldCCityContext db)
        {
            TblUserVolumes tblUserVolumes = new TblUserVolumes();
            tblUserVolumes.UserAuthId = userAuth.Id;

            db.TblUserVolumes.Add(tblUserVolumes);
            db.SaveChanges();

            return true;

        }
    }
}
