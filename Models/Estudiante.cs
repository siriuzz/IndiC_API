using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace IndiC_API.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono {  get; set; }
        public string Cedula { get; set; }
        public string Password { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public string Direccion {  get; set; }
        public string Configuracion {  get; set; }
        //public int Id_Carrera { get; set; }
        //public int Id_Asignatura { get;set; }
        //public int Id_Estado { get; set; }
        //public int Id_Rol { get; set; }
    }
}
