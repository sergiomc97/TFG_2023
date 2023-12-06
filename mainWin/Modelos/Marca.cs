using System;
using System.Collections.Generic;

namespace mainWin.Modelos;

public partial class Marca
{
    public int IdMarca { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
