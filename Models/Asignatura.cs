using System;
using System.Collections.Generic;

namespace IndiC_API.Models;

public partial class Asignatura
{
    public int IdAsignatura { get; set; }

    public string Asignatura1 { get; set; } = null!;

    public int IdDocente { get; set; }

    public int Creditos { get; set; }

    public string Aula { get; set; } = null!;

    public bool Activa { get; set; }

    public int CalificacionBaseMt { get; set; }

    public virtual ICollection<EstudianteAsignatura> EstudianteAsignaturas { get; set; } = new List<EstudianteAsignatura>();

    public virtual Docente IdDocenteNavigation { get; set; } = null!;
}
