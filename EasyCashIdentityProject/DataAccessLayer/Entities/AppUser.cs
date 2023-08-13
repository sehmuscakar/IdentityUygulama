using DataAccessLayer.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
   public class AppUser: IdentityUser<int>  // IdentityUser: veritabanındaki  aspnetusers tablosuyla ilişkiye koyacaz ve ordaki tabloya eklmek istediğimniz verileri ekleyecez ;IdentityUser =aspnetusers tablosu gibi düşün
    {//<int> bunu toblodaki id primary si string ti bunu int ecevirdik bu yuzden ve gerekli diğer tablolarıda çevir role me filan daha sağlıklı

        public string Name { get; set; }
        public string Surname { get; set; }
        public string District { get; set; }//ilçe 
        public string City { get; set; }
        public string ImageUrl { get; set; }

        public int ConfirmCode { get; set; }//onay kodu,mail doğrulama işlemi için kullanılacak ,migration olduğunda migration da nullable yi true yaptık ayrıntı
        public List<CustomerAccount> CustomerAccounts { get; set; }     

    }
}
