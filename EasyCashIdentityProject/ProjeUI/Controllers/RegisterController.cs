using DataAccessLayer.Entities;
using DataAccessLayer.Dtos.AppUserDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;

namespace ProjeUI.Controllers
{
    public class RegisterController : Controller
    {

        private readonly UserManager<AppUser> _userManager; // bu sınıf ıdentity içinde bulunan hazır bir sınıf 

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto) //AppUserRegisterDto bu modeli kullanma amacımız sadece gerekli propertyleri kullanmak için 
        {
            if (ModelState.IsValid)
            {
                Random random= new Random();
                int code;
                code = random.Next(100000, 1000000);//1 .ci değer dahil 2.ci değer dahildeğil
				AppUser appUser = new AppUser() // atamalarımızı yaptık
                {
                    UserName = appUserRegisterDto.UserName,
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                    Email = appUserRegisterDto.Email,
                    City = "aaa",
                    District = "aaaa",
                    ImageUrl = "ccc",
                    // burda entityin kendi tablolarındaki propertylerinde bazıları nul gecçe veya geçmeme onlara dikat et senin yazdığın validasyonlarınla ilgisi yok onları kontrol etmen lazım 
                    ConfirmCode =code,
                };

                var result= await _userManager.CreateAsync(appUser,appUserRegisterDto.Password);//eklemeleri yapacak ilgili olanları ve result değişkenine atama yapacak
                if (result.Succeeded)
                {
					// bu kodların hepsi scakar542@gmail.com mailinden örnek sehmuscakar617@gmail.com a mail yani onay kodu gönderdik ,scakar542@gmail.com bunun mutlaka iki adımlı doğrulaması açık olması lazım 
					MimeMessage mimeMessage = new MimeMessage();// minekit kütüphanesi eklemen lazım bunun için maile doğrulama yapmak için 

                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Şehmus", "scakar542@gmail.com");//kimden geleceği isim ve adres
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);//kime gideği isim ve adres

                    mimeMessage.From.Add(mailboxAddressFrom);//kimden gelecek ekle
                        
                    mimeMessage.To.Add(mailboxAddressTo);//kime gidecek ekle

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz" + code;
                    mimeMessage.Body=bodyBuilder.ToMessageBody();   //mesaja ekle body kısmına 

                    mimeMessage.Subject = "Easy Cash Onay Kodu";//konu kısmı

                    SmtpClient client=new SmtpClient();// mail trnsfer nesne örneği protokol
                    client.Connect("smtp.gmail.com", 587, false);//prokol gereklikleri bağlantı kurma ,burda bağlatı güvenliğine false dedik çünkü ConfirmMailController da true işlemi yapacaz emailconfirmed

                    client.Authenticate("scakar542@gmail.com", "eexmhajumwfdsbwd");//mail ve mailde oluşturduğun güvenlik kodu
                    client.Send(mimeMessage);//gönder
                    client.Disconnect(true);//gövenli çıkış yap 
                    //bu işlemi yapman için iki adımlı doğrulamyı mail de açman lazım

                    TempData["Mail"] = appUserRegisterDto.Email;// bu ksıım taşımkla  ilgili bu tempdata nın içine sakladık maili 

					return RedirectToAction("Index", "ConfirmMail"); //ekleme olduktan sonra mail doğrulama controlerına yönlendirecek
                }

                else
                {
                    foreach (var item in result.Errors) //model içindeki hata mesajlarını bize dçndürecek bu , senin tanımladığın validasyonlar çalışıyor onlar bunlar ayrı sistemsel hatalar çoğunluıkla ingilizce hatalar yani çok önemli bu ksıım 
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
        
            return View();
        }
    }
}
//mvc veya ıdentityde şifre buna benzer kurallar vardır dikkat et 
// en az 6 karekter
// en az 1 küçük harf 
// en az 1 büyük harf 
// en az 1 sembol
// en az bir sayı