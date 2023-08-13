using Microsoft.AspNetCore.Mvc;

namespace ProjeUI.ViewComponents.Customer
{
    public class _CustomerHeaderLayoutPartial:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
