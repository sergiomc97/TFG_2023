using System;
using System.Collections.Generic;

namespace mainWin.Modelos;

public partial class Estado
{
    public int IdEstado { get; set; }

    public string? Estado1 { get; set; }

    public virtual ICollection<Ordene> Ordenes { get; set; } = new List<Ordene>();

    public virtual ICollection<Pendiente> Pendientes { get; set; } = new List<Pendiente>();
}
