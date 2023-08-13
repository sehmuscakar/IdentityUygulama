using DataAccessLayer.Dtos.AppUserDtos;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ProjeUI.Controllers
{
    [Authorize]//login ile giriş yapılması lazım bu controllerı erişmek için 
    public class MyAccountController : Controller // sisteme otantike olan kişinin verilerini getirmek için kullanacaz bu controllerı
    {
        private readonly UserManager<AppUser> _userManager;

        public MyAccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        // net core ıdentityde 4 tane find by türü vardır.
        // 1.cisi FindByEmailAsync:sisteme giriş yapan lişin mail adresine göre işlem yapıyor
        //2.cisi FindByIdAsync:sisteme giriş yapan lişin ıd sine göre işlem yapıyor  
        //3. cüsü FindByNameAsync burdaki name aslında username karşılıyor :sisteme giriş yapan lişin name  göre işlem yapıyor
        // 4.cüsü FindByLoginAsync bunu araştır istersen sonra belki

        [HttpGet]
        public async Task<IActionResult> Index() // otantike olan kişinin verilerini getirme işlemi yapıyoruz burda 
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name); // burda sisteme login olan otantike olan kişin bilgilerini name göre bulacak ve getirecek yani username göre diyeebiliriz
            AppUserEditDto appUserEditDto =new AppUserEditDto();// bu bi nevi view model olarak hareket edecek
            appUserEditDto.Name = values.Name;
            appUserEditDto.Surname= values.Surname;
            appUserEditDto.PhoneNumber = values.PhoneNumber;
            appUserEditDto.Email = values.Email;
            appUserEditDto.City= values.City;
            appUserEditDto.District= values.District;
            appUserEditDto.ImageUrl= values.ImageUrl;
            return View(appUserEditDto);

        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserEditDto appUserEditDto)
        {
            if (appUserEditDto.Password == appUserEditDto.ConfirmPassword)//ikişfrede aynısı ise 
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);//username göre önceliğğinde hareket edecek

                user.PhoneNumber = appUserEditDto.PhoneNumber;
                user.Surname= appUserEditDto.Surname;
                user.City= appUserEditDto.City;
                user.District=appUserEditDto.District;
                user.Name= appUserEditDto.Name;
                user.ImageUrl = "test";
                user.Email=appUserEditDto.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserEditDto.Password);//şifremizi gene gizli bi şekide veri tabanımıza göndereecez bu kod sayesinde 
                var resut=await _userManager.UpdateAsync(user);
                if (resut.Succeeded) // eğer güncelleme başarılı ise loginin indexine yönlendir
                {
                    return RedirectToAction("Index", "Login");
                }

            }


            return View();
        }

    }
}
