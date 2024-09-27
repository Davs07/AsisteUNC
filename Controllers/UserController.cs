using Microsoft.AspNetCore.Mvc;

namespace AsitenciaUNC_attemp_2.Controllers
{
	public class UserController : Controller
	{
		public readonly ILogger<UserController> _logger;
		public UserController(ILogger<UserController> logger)
		{
			_logger = logger;
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
