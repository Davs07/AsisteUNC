using AsitenciaUNC_attemp_2.Models;

namespace AsitenciaUNC_attemp_2.ViewModels
{
    public class IndexVM
    {
        public List<Evento> Eventos { get; set; }
        public int PaginaActual { get; set; }
        public int TotalPaginas { get; set; }
        public string Buscar { get; set; }
    }
}