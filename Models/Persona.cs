using System;
using System.Collections.Generic;

namespace NOMIN.Models;

public partial class Persona
{
    public int Secuencia { get; set; }

    public string? Factorrh { get; set; }

    public DateTime? Fechanacimiento { get; set; }

    public string? Gruposanguineo { get; set; }

    public string Nombre { get; set; } = null!;

    public int Numerodocumento { get; set; }

    public string Primerapellido { get; set; } = null!;

    public string? Segundoapellido { get; set; }

    public string? Sexo { get; set; }

    public int Ciudadnacimiento { get; set; }

    public int? Ciudaddocumento { get; set; }

    public int Tipodocumento { get; set; }

    public string? Email { get; set; }

    public string? Segundonombre { get; set; }

    public virtual ICollection<Empledo> Empledos { get; set; } = new List<Empledo>();
}
