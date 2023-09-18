using System;
using System.Collections.Generic;

namespace IndiC_API.Models;

public partial class Docente
{
    public int IdDocente { get; set; }

    public string NombreDocente { get; set; } = null!;

    public string CorreoDocente { get; set; } = null!;

    public int TelefonoDocente { get; set; }

    public int CedulaDocente { get; set; }

    public string PasswordDocente { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public string Direccion { get; set; } = null!;

    public int IdAsignatura { get; set; }

    public int IdEstado { get; set; }

    public int IdRol { get; set; }

    public string Configuracion { get; set; } = null!;

    public virtual ICollection<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();

    public virtual Estado IdEstadoNavigation { get; set; } = null!;

    public virtual Role IdRolNavigation { get; set; } = null!;
}
