using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mainWin.Modelos;

public partial class Ordene
{
    public int IdOrden { get; set; }

    public DateTime? Fecha { get; set; }

    public int? ClienteId { get; set; }

    public int? AsignadoId { get; set; }

    public long? ProductoId { get; set; }

    public int? EstadoId { get; set; }

    public int? ServicioId { get; set; }

    public DateTime? FechaComp { get; set; }

    public DateTime? FechaEnt { get; set; }

    public string? Prioridad { get; set; }

    public string? Modelo { get; set; }

    public string? Averia { get; set; }

    public string? Solucion { get; set; }

    public string? Observaciones { get; set; }

    public string? Telefono { get; set; }

    public string? ClienteStr { get; set; }

    public string? CliDni { get; set; }

    public string? CliDirec { get; set; }

    [Timestamp]
    public DateTime? RowVersion { get; set; }

    public virtual Empleado? Asignado { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual Producto? Producto { get; set; }

    public virtual Servicio? Servicio { get; set; }

    public override string ToString() {
        return $"IdOrden: {IdOrden}" +
               $"ClienteStr: {ClienteStr}" +
               $"Asignado: {Asignado.Nombre}" +
               $"Estado: {Estado}";
    }
}
