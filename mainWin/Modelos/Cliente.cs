using System;
using System.Collections.Generic;

namespace mainWin.Modelos;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public string? Dni { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Ordene> Ordenes { get; set; } = new List<Ordene>();
}
