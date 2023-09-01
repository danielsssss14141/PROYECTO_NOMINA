using System;
using System.Collections.Generic;

namespace NOMIN.Models;

public partial class Tiposunidade
{
    public int Secuencia { get; set; }

    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Unidade> Unidades { get; set; } = new List<Unidade>();
}
