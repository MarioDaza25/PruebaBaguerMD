namespace PruebaBaguerMD.Models;

public class Rol : BaseEntity
{
    public string Descripcion { get; set; }

    public ICollection<Usuario> Usuarios { get; set; }
}
