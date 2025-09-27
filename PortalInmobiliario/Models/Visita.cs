using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PortalInmobiliario.Models;

public enum EstadoVisita { Solicitada, Confirmada, Cancelada }

public class Visita
{
    public int Id { get; set; }
    public int InmuebleId { get; set; }
    public string UsuarioId { get; set; }

    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public EstadoVisita Estado { get; set; }

    [StringLength(500)]
    public string? Notas { get; set; }

    public Inmueble Inmueble { get; set; }
    public IdentityUser Usuario { get; set; }
}