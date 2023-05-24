using System;
using System.Collections.Generic;

namespace DL;

public partial class Libro
{
    public int IdLibro { get; set; }

    public int? IdAutor { get; set; }

    public string? TituloLibro { get; set; }

    public DateTime AñoPublicacion { get; set; }

    public int? IdEditorial { get; set; }

    public string? Portada { get; set; }

    public string? Sinopsis { get; set; }

    public virtual Autor? IdAutorNavigation { get; set; }

    public virtual Editorial? IdEditorialNavigation { get; set; }



    public string? Nombre { get; set; }
    public string? Editorial { get; set; }
    public string? ApellidoPaterno { get; set; }
    public string? ApellidoMaterno { get; set; }
}
