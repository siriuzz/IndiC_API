using System;
using System.Collections.Generic;

namespace IndiC_API.Models;

public partial class Estado
{
    public int IdEstado { get; set; }

    public string Estado1 { get; set; } = null!;

    public virtual ICollection<Docente> Docentes { get; set; } = new List<Docente>();

    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
}
