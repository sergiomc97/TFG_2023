using System;
using System.Collections.Generic;

namespace mainWin.Modelos;

public partial class Configuracion
{
    public int IdConfig { get; set; }

    public int? Usuario_id { get; set; }

    public string? RutaFS { get; set; }

    public string? Opcion2 { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
