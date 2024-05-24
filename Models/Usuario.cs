namespace PruebaBaguerMD.Models;

public class Usuario : BaseEntity
{
    public string Nombre { get; set; }
    public string NombreUsuario { get; set; }
    public string Contraseña { get; set; }
    public string Correo { get; set; }
    public int RolId { get; set; }
    public Rol Rol { get; set; }
}
