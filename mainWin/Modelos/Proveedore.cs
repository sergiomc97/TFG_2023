using System;
using System.Collections.Generic;

namespace mainWin.Modelos;

public partial class Proveedore
{
    public int IdProveedor { get; set; }

    public string? Empresa { get; set; }

    public string? PersonaCont { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public string? SitioWeb { get; set; }

    public string? Desc { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
