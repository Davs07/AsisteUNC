using AsitenciaUNC_attemp_2.Models;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace AsitenciaUNC_attemp_2.Controllers
{
	public class CheckinController : Controller
	{
		private readonly ILogger<CheckinController> _logger;

		public CheckinController(ILogger<CheckinController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Qr(string texto)
		{
			QRCodeGenerator qrGenerator = new QRCodeGenerator();
			QRCodeData qrCodeData = qrGenerator.CreateQrCode(texto, QRCodeGenerator.ECCLevel.Q);
			PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
			byte[] qrCodeImage = qrCode.GetGraphic(20);
			string model = Convert.ToBase64String(qrCodeImage);
			return View("Qr", model);
		}


		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}

}
