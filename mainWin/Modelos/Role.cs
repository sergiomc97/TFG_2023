using System;
using System.Collections.Generic;

namespace mainWin.Modelos;

public partial class Role
{
    public int IdRol { get; set; }

    public string? Rol { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
