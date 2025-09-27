using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalInmobiliario.Data;
using PortalInmobiliario.Models;

namespace PortalInmobiliario.Controllers;

public class CatalogoController : Controller
{
    private readonly ApplicationDbContext _context;

    public CatalogoController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string ciudad, TipoInmueble? tipo, decimal? precioMin, decimal? precioMax, int? dormitorios, int pagina = 1)
    {
        var query = _context.Inmuebles.Where(i => i.Activo);

        if (!string.IsNullOrEmpty(ciudad))
        {
            query = query.Where(i => i.Ciudad == ciudad);
        }
        if (tipo.HasValue)
        {
            query = query.Where(i => i.Tipo == tipo.Value);
        }
        if (precioMin.HasValue)
        {
            query = query.Where(i => i.Precio >= precioMin.Value);
        }
        if (precioMax.HasValue)
        {
            query = query.Where(i => i.Precio <= precioMax.Value);
        }
        if (dormitorios.HasValue)
        {
            query = query.Where(i => i.Dormitorios >= dormitorios.Value);
        }

        const int tamanoPagina = 8; 
        var totalInmuebles = await query.CountAsync();
        var inmueblesPaginados = await query.Skip((pagina - 1) * tamanoPagina)
                                            .Take(tamanoPagina)
                                            .ToListAsync();

        var viewModel = new CatalogoViewModel
        {
            Inmuebles = inmueblesPaginados,
            Ciudades = new SelectList(await _context.Inmuebles.Select(i => i.Ciudad).Distinct().ToListAsync()),
            Tipos = new SelectList(Enum.GetValues(typeof(TipoInmueble))),
            CiudadFiltro = ciudad,
            TipoFiltro = tipo,
            PrecioMinFiltro = precioMin,
            PrecioMaxFiltro = precioMax,
            DormitoriosFiltro = dormitorios,
            PaginaActual = pagina,
            TotalPaginas = (int)Math.Ceiling(totalInmuebles / (double)tamanoPagina)
        };

        return View(viewModel);
    }
    
    public async Task<IActionResult> Detalle(int id)
    {
        var inmueble = await _context.Inmuebles.FindAsync(id);
        if (inmueble == null || !inmueble.Activo)
        {
            return NotFound();
        }
        return View(inmueble);
    }
}