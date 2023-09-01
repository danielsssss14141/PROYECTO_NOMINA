using System;
using System.Collections.Generic;

namespace NOMIN.Models;

public partial class Motivoscambiossueldo
{
    public int Secuencia { get; set; }

    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Vigenciassueldo> Vigenciassueldos { get; set; } = new List<Vigenciassueldo>();
}
