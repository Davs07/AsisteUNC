using AsitenciaUNC_attemp_2.Enums;
using AsitenciaUNC_attemp_2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AsitenciaUNC_attemp_2.ViewModels
{
	public class IndexVM
	{
		public List<Evento> Eventos { get; set; }
		public int PaginaActual { get; set; }
		public int TotalPaginas { get; set; }
		public string Buscar { get; set; }
		public TipoEvento? TipoEvento { get; set; }
		public SelectList TiposEventos { get; set; } // Usa SelectList para simplificar el bind en la vista
		public DateTime? FechaInicio { get; set; } // Fecha de inicio para el filtro
		public DateTime? FechaFin { get; set; }, // Fecha de fin para el filtro

		// filtrar por los usuarios organizadores

	}
}