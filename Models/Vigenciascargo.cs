using System;
using System.Collections.Generic;

namespace NOMIN.Models;

public partial class Vigenciascargo
{
    public int Secuencia { get; set; }

    public int Cargo { get; set; }

    public int Empleado { get; set; }

    public DateTime Fechavigencia { get; set; }

    public int Motivocambiocargo { get; set; }

    public int? Claseriesgo { get; set; }

    public virtual Cargo CargoNavigation { get; set; } = null!;

    public virtual Clasesriesgo? ClaseriesgoNavigation { get; set; }

    public virtual Empledo EmpleadoNavigation { get; set; } = null!;

    public virtual Motivoscambioscargo MotivocambiocargoNavigation { get; set; } = null!;
}
