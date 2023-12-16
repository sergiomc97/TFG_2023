using System;
using System.Collections.Generic;

namespace mainWin.Modelos;

public partial class Producto
{
    public long IdProducto { get; set; }

    public string? Producto1 { get; set; }

    public decimal? Costo { get; set; }

    public decimal? Precio { get; set; }

    public int? Marca_id { get; set; }

    public int? Existencias { get; set; }

    public int? Categoria_id { get; set; }

    public int? Proveedor_id { get; set; }

    public virtual Categoria? Categoria { get; set; }

    public virtual Marca? Marca { get; set; }

    public virtual ICollection<Ordene> Ordenes { get; set; } = new List<Ordene>();

    public virtual Proveedore? Proveedor { get; set; }
}
