using System;
using System.Collections.Generic;

namespace mainWin.Modelos;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? Nombre { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public int? RolId { get; set; }

    public virtual ICollection<Ordene> Ordenes { get; set; } = new List<Ordene>();

    public virtual Role? Rol { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    public override string ToString() {
        return Nombre;
    }
}
