using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
   public class Context:IdentityDbContext<AppUser,AppRole,int> // biz ıdentity imiz büylece özeleştirdik appuser ,approle ve int olarak genel primary olarak stringten int e cevirdik user ile ilgili biz özel olarak hangitabloları yapmışsak buraya da eklememiz lazım 
    {
        //,int> bu int primary i leri strigten int e cevirecek genel olarak diğer paremeetrelede özeleştirilmiş olanlar primary meselesi özeleştirilmiş tablolarda da yapıldı yapılmış olamsı lazım dikkat et
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-PBFD0LU;  database=DBEasyCash; integrated security=true; TrustServerCertificate=true");
        }
        // identityde özeleştirilmiş olan sınıflarımızı dbset olarak eklememize gerek yok migration ve update yapman yeterli ama ilgili migrationları veya genel migration kalsörünü ve db yi silip baştan yaparsan daha sağlıklı olur 
       
        // sonra db yi katrol et özeleşrtirilmiş tabloları diyagram oluştur ilşkilerde bi sıkıntı yoksa sıkıntı yoktur devam et.
        
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<CustomerAccountProcess> CustomerAccountProcesses { get; set; }
    }
}
