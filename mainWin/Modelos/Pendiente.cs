using System;
using System.ComponentModel.DataAnnotations;

namespace mainWin.Modelos;

public partial class Pendiente
{
    public int IdPendientes { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Nombre { get; set; }

    public bool? Completado { get; set; }

    public string? Telefono { get; set; }

    public string? Pedido { get; set; }

    public decimal? Anticipo { get; set; }

    public decimal? Precio { get; set; }

    public int? Estado_id { get; set; }
    [Timestamp]
    public DateTime? RowVersion { get; set; }

    public virtual Estado? Estado { get; set; }
}
