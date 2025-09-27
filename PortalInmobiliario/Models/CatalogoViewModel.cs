using Microsoft.AspNetCore.Mvc.Rendering;

namespace PortalInmobiliario.Models;

public class CatalogoViewModel
{
    public List<Inmueble> Inmuebles { get; set; }
    
    // Para los dropdowns de los filtros
    public SelectList Ciudades { get; set; }
    public SelectList Tipos { get; set; }

    // Propiedades para mantener los valores de los filtros
    public string? CiudadFiltro { get; set; }
    public TipoInmueble? TipoFiltro { get; set; }
    public decimal? PrecioMinFiltro { get; set; }
    public decimal? PrecioMaxFiltro { get; set; }
    public int? DormitoriosFiltro { get; set; }
    
    // Para la paginación
    public int PaginaActual { get; set; }
    public int TotalPaginas { get; set; }
}