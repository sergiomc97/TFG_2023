using System;
using System.Collections.Generic;

namespace mainWin.Modelos;

public partial class Producto
{
    public long IdProducto { get; set; }

    public string? Producto1 { get; set; }

    public decimal? Costo { get; set; }

    public decimal? Precio { get; set; }

    public int? MarcaId { get; set; }

    public int? Existencias { get; set; }

    public int? CategoriaId { get; set; }

    public int? ProveedorId { get; set; }

    public virtual Categoria? Categoria { get; set; }

    public virtual Marca? Marca { get; set; }

    public virtual ICollection<Ordene> Ordenes { get; set; } = new List<Ordene>();

    public virtual Proveedore? Proveedor { get; set; }
}
