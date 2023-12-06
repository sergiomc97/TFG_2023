using Microsoft.VisualBasic;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;

namespace mainWin.Modelos;

public partial class Cita
{
    public int IdCita { get; set; }

    public DateOnly? Fecha { get; set; }

    public TimeOnly? Hora { get; set; }

    public int? ClienteId { get; set; }

    public string? Desc { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public override string ToString() {
        return IdCita.ToString();
    }
}
