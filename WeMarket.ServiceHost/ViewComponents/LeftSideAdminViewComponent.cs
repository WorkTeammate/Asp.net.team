using Microsoft.AspNetCore.Mvc;

namespace WeMarket.ServiceHost.ViewComponents
{
    public class LeftSideAdminViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
