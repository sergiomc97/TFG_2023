using System;
using System.Collections.Generic;

namespace mainWin.Modelos;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public string? Servicio1 { get; set; }

    public virtual ICollection<Ordene> Ordenes { get; set; } = new List<Ordene>();
}
