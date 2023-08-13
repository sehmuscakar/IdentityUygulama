using Microsoft.AspNetCore.Mvc;

namespace ProjeUI.Controllers
{
    public class CustomerLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
