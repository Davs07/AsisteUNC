using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AsitenciaUNC_attemp_2.Controllers.User
{
    [Authorize]
    public class UsuarioController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
