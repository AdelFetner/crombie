using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioComponent;

public class Usuario
{
    public string Nombre { get; set; }
    public int UserID { get; set; }

    public ArrayList LibrosPrestados { get; set; }

    public Usuario(string Nombre, int UserID)
    {
        this.Nombre = Nombre;
        this.UserID = UserID;
        LibrosPrestados = new ArrayList();
    }
}
