using System;
using System.Collections.Generic;

namespace IndiC_API.Models;

public partial class Role
{
    public int IdRoles { get; set; }

    public string Rol { get; set; } = null!;

    public virtual ICollection<Docente> Docentes { get; set; } = new List<Docente>();

    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
}
