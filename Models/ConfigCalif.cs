using System;
using System.Collections.Generic;

namespace IndiC_API.Models;

public partial class ConfigCalif
{
    public int IdConfig { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Estado { get; set; }
}
