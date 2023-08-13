using Microsoft.AspNetCore.Mvc;

namespace ProjeUI.ViewComponents.Customer
{
    public class _CustomerLayoutSidebarPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
