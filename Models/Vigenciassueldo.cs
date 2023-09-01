using System;
using System.Collections.Generic;

namespace NOMIN.Models;

public partial class Vigenciassueldo
{
    public int Secuencia { get; set; }

    public int Empleado { get; set; }

    public DateTime Fechavigencia { get; set; }

    public int Motivocambiosueldo { get; set; }

    public int Tiposueldo { get; set; }

    public int Unidadpago { get; set; }

    public decimal Valor { get; set; }

    public virtual Empledo EmpleadoNavigation { get; set; } = null!;

    public virtual Motivoscambiossueldo MotivocambiosueldoNavigation { get; set; } = null!;

    public virtual Tipossueldo TiposueldoNavigation { get; set; } = null!;

    public virtual Unidade UnidadpagoNavigation { get; set; } = null!;
}
