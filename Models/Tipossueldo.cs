using System;
using System.Collections.Generic;

namespace NOMIN.Models;

public partial class Tipossueldo
{
    public int Secuencia { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? Codigo { get; set; }

    public virtual ICollection<Vigenciassueldo> Vigenciassueldos { get; set; } = new List<Vigenciassueldo>();
}
