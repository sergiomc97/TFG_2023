using System;
using System.ComponentModel.DataAnnotations;

namespace mainWin.Modelos;

public partial class Ordene
{
    public int IdOrden { get; set; }

    public DateTime? Fecha { get; set; }

    public int? Cliente_id { get; set; }

    public int? Asignado_id { get; set; }

    public long? Producto_id { get; set; }

    public int? Estado_id { get; set; }

    public int? Servicio_id { get; set; }

    public DateTime? Fecha_comp { get; set; }

    public DateTime? Fecha_ent { get; set; }

    public string? Prioridad { get; set; }

    public string? Modelo { get; set; }

    public string? Averia { get; set; }

    public string? Solucion { get; set; }

    public string? Observaciones { get; set; }

    public string? Telefono { get; set; }

    [Timestamp]
    public DateTime? RowVersion { get; set; }

    public virtual Empleado? Asignado { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual Producto? Producto { get; set; }

    public virtual Servicio? Servicio { get; set; }
    public override string ToString() {
        return $"IdOrden: {IdOrden}, Fecha: {Fecha?.ToString("yyyy-MM-dd")}, Cliente: {Cliente?.Nombre}, Asignado: {Asignado?.Nombre}";
    }
}
