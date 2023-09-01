using System;
using System.Collections.Generic;

namespace NOMIN.Models;

public partial class Clasesriesgo
{
    public int Secuencia { get; set; }

    public int Codigo { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal? Porcentaje { get; set; }

    public virtual ICollection<Vigenciascargo> Vigenciascargos { get; set; } = new List<Vigenciascargo>();
}
