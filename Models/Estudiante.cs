using System;
using System.Collections.Generic;

namespace IndiC_API.Models;

public partial class Estudiante
{
    public int IdEstudiante { get; set; }

    public string NombreEstudiante { get; set; } = null!;

    public string CorreoEstudiante { get; set; } = null!;

    public string TelefonoEstudiante { get; set; } = null!;

    public int CedulaEstudiante { get; set; }

    public string PasswordEstudiante { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public string Direccion { get; set; } = null!;

    public string Configuracion { get; set; } = null!;

    public string IdCarrera { get; set; } = null!;

    public int IdAsignatura { get; set; }

    public int IdEstado { get; set; }

    public int IdRol { get; set; }

    public int PeriodosCursados { get; set; }

    public virtual ICollection<EstudianteAsignatura> EstudianteAsignaturas { get; set; } = new List<EstudianteAsignatura>();

    public virtual Carrera IdCarreraNavigation { get; set; } = null!;

    public virtual Estado IdEstadoNavigation { get; set; } = null!;

    public virtual Role IdRolNavigation { get; set; } = null!;
}
