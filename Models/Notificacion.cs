namespace AsitenciaUNC_attemp_2.Models

{
    public class Notificacion
	{
		public int Id { get; set; }
		public string UsuarioId { get; set; }
		public Usuario Usuario { get; set; }
		public string Mensaje { get; set; }
		public bool Leido { get; set; } = false;
		public DateTime CreadoEn { get; set; } = DateTime.Now;
	}
}
