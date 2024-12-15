namespace Crombievents.Models
{
    public class UserModel
    {
            public int UsuarioID { get; set; }
            public string Nombre { get; set; }
            public string Email { get; set; }
            public string Telefono { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
