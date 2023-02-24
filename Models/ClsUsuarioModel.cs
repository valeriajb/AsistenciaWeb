namespace AsistenciaHuellaWeb.Models
{
    public class ClsUsuarioModel
    {
        public int Id_Usuario { get; set; }
        public string Cedula_Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Apellido_Usuario { get; set; }
        public string Correo_Usuario { get; set; }
        public string Celular_Usuario { get; set; }
        public string Password_Usuario { get; set; }
        public string Rol_Usuario { get; set; }
        public string Estado_Usuario { get; set; }
        public byte Photo_Usuario { get; set; }

    }
}
