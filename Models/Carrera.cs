using System;
using System.Collections.Generic;

namespace IndiC_API.Models;

public partial class Carrera
{
    public string IdCarrera { get; set; } = null!;

    public string Carrera1 { get; set; } = null!;

    public int PeriodosTotales { get; set; }

    public int AsignaturasTotales { get; set; }

    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
}
