using Microsoft.AspNetCore.Mvc;

public class CurriculoController : Controller
{
    public IActionResult Index()
    {
        Guid geradorGuid = Guid.NewGuid();

        ViewBag.GuidValue = geradorGuid;
        
        return View();
    }
}
