using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities.Concrete
{
public class CustomerAccount
    {
        public int CustomerAccountID { get; set; }//MüşteriHesabı Kimliği
        public string CustomerAccountNumber { get; set; }//MüşteriHesapNumarası
        public string CustomerAccountCurrency { get; set; }//   MüşteriHesabıPara Birimi
        public decimal CustomerAccountBalance { get; set; } //Müşteri HesabıBakiyesi
        public string BankBranch { get; set; } //  Banka şubesi


        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }

    }
}
