using System;
using System.Collections.Generic;

namespace mainWin.Modelos;

public partial class Usuario
{

    public int Iduser { get; set; }

    public string? Nick { get; set; }

    public int? RolId { get; set; }

    public string? Mail { get; set; }

    public byte[]? PasswordHash { get; set; }

    public byte[]? Salt { get; set; }

    public int? EmpleadoId { get; set; }

    public virtual ICollection<Configuracion> Configuracions { get; set; } = new List<Configuracion>();

    public virtual Empleado? Empleado { get; set; }

    public virtual Role? Rol { get; set; }
}
