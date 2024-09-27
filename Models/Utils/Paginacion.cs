namespace AsitenciaUNC_attemp_2.Models.Utils
{
    public class Paginacion
    {
        public int PaginaActual { get; set; }
        public int TotalRegistros { get; set; }
        public int RegistroPorPagina { get; set; }
        public RouteValueDictionary ValoresQueryString { get; set; } //permite trabajar con Url y rutas
    }
}