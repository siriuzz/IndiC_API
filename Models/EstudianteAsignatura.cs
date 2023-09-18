using System;
using System.Collections.Generic;

namespace IndiC_API.Models;

public partial class EstudianteAsignatura
{
    public int IdEstudiante { get; set; }

    public int IdAsignatura { get; set; }

    public int CalificacionMt { get; set; }

    public int CalificacionFinal { get; set; }

    public virtual Asignatura IdAsignaturaNavigation { get; set; } = null!;

    public virtual Estudiante IdEstudianteNavigation { get; set; } = null!;
}
