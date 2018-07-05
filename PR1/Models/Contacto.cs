using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PR1.Models
{
    public class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        // creamos el constructor del objeto con valores default
        public Contacto()
        {
            Id = -1;
            Nombre = string.Empty;
            Apellido= string.Empty;
        }

    }
}