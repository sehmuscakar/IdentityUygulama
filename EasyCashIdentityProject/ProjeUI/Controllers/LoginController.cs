using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjeUI.Models;

namespace ProjeUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel) // peek defination diyereek direk bu sayfanın içinden  o modelini dolduurabilirsin 
        {
            var result=await _signInManager.PasswordSignInAsync(loginViewModel.Username,loginViewModel.Password,true,true);//true,true ;1.ci true browser kapandıktan sonra sişfre hatırlansın mı
                                                                                                                           //2.ci true ise accessfailedcount nin aktif olması yani kullanıcı her yanlış girdiğinde 1 artacak ve 5 olduğunda onu loglayacak engeleyece beli süre aralığında 20 dk ciivarı herhalde bilmiyorum tam 
            if (result.Succeeded)
            {
                var user=await _userManager.FindByNameAsync(loginViewModel.Username);//kayıt olan username i bulur 
                if (user.EmailConfirmed==true)
                {
                    return RedirectToAction("Index", "MyAccount");
                }
                //else lütfen mail adresinizi onaylayın //tercih edilmez bence 
            }  
            //kullanıcı adı veya şifre hatalı // tercih edilmez sıkıntı yaratır hata 
            return View();
        }
    }
}
