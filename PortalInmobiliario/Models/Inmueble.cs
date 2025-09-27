using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalInmobiliario.Models;

public enum TipoInmueble { Departamento, Casa, Oficina, Local }

public class Inmueble
{
    public int Id { get; set; }

    [Required]
    public string Codigo { get; set; }

    [Required]
    [StringLength(100)]
    public string Titulo { get; set; }

    public string Imagen { get; set; }

    public TipoInmueble Tipo { get; set; }

    [Required]
    public string Ciudad { get; set; }

    [Required]
    public string Direccion { get; set; }

    public int Dormitorios { get; set; }
    public int Banos { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal MetrosCuadrados { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Precio { get; set; }

    public bool Activo { get; set; } = true;
}