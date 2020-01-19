using Microsoft.VisualStudio.TestTools.UnitTesting;
using CryptoCityWallet.Entities.BO;
using CryptoCityWallet.Entities.Enums;
using CryptoCityWallet.AppService;

namespace CryptoCityWallet.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EmailTest()
        {
            UserBO userBO = new UserBO() {
                FirstName = "Jay",
                LastName = "Eraldo",
                Email = "jjeeraldo@gmail.com"            
            };
            MailAppService mailAppService = new MailAppService();
            bool response = mailAppService.SendSmtp(userBO, EmailType.EmailConfirmation);
        }
    }
}
