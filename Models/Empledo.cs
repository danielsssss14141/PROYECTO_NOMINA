using System;
using System.Collections.Generic;

namespace NOMIN.Models;

public partial class Empledo
{
    public int Secuencia { get; set; }

    public int Codigoempleado { get; set; }

    public int Persona { get; set; }

    public int Telefono { get; set; }

    public int Empresa { get; set; }

    public virtual Empresa EmpresaNavigation { get; set; } = null!;

    public virtual Persona PersonaNavigation { get; set; } = null!;

    public virtual ICollection<Vigenciascargo> Vigenciascargos { get; set; } = new List<Vigenciascargo>();

    public virtual ICollection<Vigenciassueldo> Vigenciassueldos { get; set; } = new List<Vigenciassueldo>();
}
