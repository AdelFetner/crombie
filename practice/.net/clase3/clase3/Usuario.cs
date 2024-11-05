using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioComponent;

public class Usuario
{
    public string Name { get; set; }
    public string ID { get; set; }
    
    public ArrayList LibrosPrestados {  get; set; }

    public Usuario(string Name, string ID)
    {
        this.Name = Name;
        this.ID = ID;
        LibrosPrestados = new ArrayList();
    }
}
