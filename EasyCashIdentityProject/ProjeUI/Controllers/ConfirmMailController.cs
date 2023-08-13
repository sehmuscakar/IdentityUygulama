using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjeUI.Models;

namespace ProjeUI.Controllers
{
	public class ConfirmMailController : Controller // register de gönderdiğimiz maili bu controllera çağıracaz işte
	{
		private readonly UserManager<AppUser> _userManager;

        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
		public IActionResult Index() // 6 haneli kodu girmek için 
		{
			var value = TempData["Mail"];
		//	ViewBag.v=value+" aaaa"; // burda viewbag aracı ile ekleme yaptık tempdataya sonra bunu ilgili index te çağıracaz 
		ViewBag.v=value;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(ConfirmMailViewModel confirmMailViewModel) //burda biz view model kullandık cok işe yaradı model view kullanımını araştır vievbag ,tempdata veri taşıma işlemleri gibi yani 
		{
			//var value = TempData["Mail"]; oladı taşınmadı böyle view model ile taşıdık confirmviewmodel
			var user = await _userManager.FindByEmailAsync(confirmMailViewModel.Mail);
			if (user.ConfirmCode ==confirmMailViewModel.ConfirmCode)
			{
				user.EmailConfirmed= true; //güvenliği true yaptık
				await _userManager.UpdateAsync(user);// günceleme yapacak yani ypdate edip db ye yansıtacak
				return RedirectToAction("Index","Login");
			}//email confirmen ksımı update edilip true ya dönecek
			return View();
		}
	}//Kullanıcı Adı -Şifre eşleşmeli <-> email confirmed olmalı
}
