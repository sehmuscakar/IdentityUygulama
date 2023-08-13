using Microsoft.AspNetCore.Mvc;

namespace ProjeUI.ViewComponents.Customer
{
    public class _CustomerLayoutNavbarPartial:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
