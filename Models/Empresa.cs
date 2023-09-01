using System;
using System.Collections.Generic;

namespace NOMIN.Models;

public partial class Empresa
{
    public int Secuencia { get; set; }

    public int Codigo { get; set; }

    public int Nit { get; set; }

    public int Codigoalternativo { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Cargo> Cargos { get; set; } = new List<Cargo>();

    public virtual ICollection<Empledo> Empledos { get; set; } = new List<Empledo>();
}
