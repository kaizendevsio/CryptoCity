using CryptoCityWallet.Entities.DTO;
using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.Enums;
using CryptoCityWallet.DataAccessLayer;
using System.Collections.Generic;
using System;
using SendGrid;
using System.Threading.Tasks;

namespace CryptoCityWallet.AppService
{
   public class ExternalRecordsAppService
    {
        public int GetDirectPartners(TblUserAuth userAuth, dbWorldCCityContext db = null)
        {
            if (db != null)
            {
                ExternalRecordsRepository externalRecordsRepository = new ExternalRecordsRepository();
                return externalRecordsRepository.GetDirectPartners(userAuth, db);
            }
            else
            {
                using (db = new dbWorldCCityContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        ExternalRecordsRepository externalRecordsRepository = new ExternalRecordsRepository();
                        return externalRecordsRepository.GetDirectPartners(userAuth, db);
                    }
                }
            }
        }

        public decimal GetInvestmentSum(TblUserAuth userAuth, dbWorldCCityContext db = null)
        {
            if (db != null)
            {
                ExternalRecordsRepository externalRecordsRepository = new ExternalRecordsRepository();
                return externalRecordsRepository.GetInvestmentSum(userAuth, db);
            }
            else
            {
                using (db = new dbWorldCCityContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        ExternalRecordsRepository externalRecordsRepository = new ExternalRecordsRepository();
                        return externalRecordsRepository.GetInvestmentSum(userAuth, db);
                    }
                }
            }
        }
    }
}
