using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dtos.AppUserDtos
{
   public class AppUserEditDto //burda sisteme otantike olan kişinin bilgilerini bu model üzerinden getirecez bu model veri transfer işlemini görecek yani
    {// bu view model dir bbunun için migration atılmaz yani 
        public string Name { get; set; }
        public string Surname { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
