using PR1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PR1.Controllers
{
    public class ContactoController : ApiController
    {
        Contacto[] contactos = new Contacto[]{
          new Contacto() { Id=1,Nombre="Leonel", Apellido="Messi"} ,
          new Contacto(){Id=2,Nombre="Cristiano",Apellido="Ronaldo"},
          new Contacto(){Id=3,Nombre="Luis",Apellido="Suarez" },
           new Contacto(){Id=3,Nombre="Andrés",Apellido="Iniesta" }
        };

        //Devolver una lista completa
        public IEnumerable<Contacto> Get()
        {
            return contactos;
        }

        public IHttpActionResult Get(int id)
        {
            // buscamos en la lista y obtenemos el primer id que encontremos
            Contacto ct = contactos.FirstOrDefault<Contacto>(x => x.Id == id);

            if(ct == null)
            {
                return NotFound();
            }

            return Ok(ct);
        }



    }
}
