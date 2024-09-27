using System.ComponentModel.DataAnnotations;

namespace AsitenciaUNC_attemp_2.ViewModels
{
	public class RegisterVM
	{
		[Required]
		public string? Nombre { get; set; }
		[Required]
		[DataType(DataType.EmailAddress)]
		public string? Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string? Contrasena { get; set; }
		[Compare("Contrasena", ErrorMessage = "Las contraseñas no coinciden")]
		[Display(Name = "Confirm Password")]
		[DataType(DataType.Password)]
		public string? ConfirmarContrasena { get; set; }
	}
}