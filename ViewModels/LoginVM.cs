using System.ComponentModel.DataAnnotations;

namespace AsitenciaUNC_attemp_2.ViewModels
{
	public class LoginVM
	{
		[Required(ErrorMessage = "El correco electrónico es requerido")]
		public string? Email { get; set; }
		[Required(ErrorMessage = "La contraseña es requerida")]
		[DataType(DataType.Password)]
		public string? Contraseña { get; set; }
		[Display(Name = "Recordarme")]
		public bool RememberMe { get; set;}
	}
}
