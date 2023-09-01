using System;
using System.Collections.Generic;

namespace NOMIN.Models;

public partial class Unidade
{
    public int Secuencia { get; set; }

    public string Nombre { get; set; } = null!;

    public int Tipounidad { get; set; }

    public string? Codigo { get; set; }

    public virtual Tiposunidade TipounidadNavigation { get; set; } = null!;

    public virtual ICollection<Vigenciassueldo> Vigenciassueldos { get; set; } = new List<Vigenciassueldo>();
}
