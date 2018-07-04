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

        //metodo post para ingresar contactos
        public IEnumerable<Contacto> Post([FromBody]Contacto nuevoContacto)
        {
            //1. hacemos una lista del array de contactos que tenemos
            List<Contacto> listaContactos = contactos.ToList<Contacto>();

            //2. generamos un id nuevo para que no se repita
            nuevoContacto.Id = listaContactos.Count;

            //3. agregamos el contacto que recibieron a la lista
            listaContactos.Add(nuevoContacto);

            //4. convertimos los contactos a un Array nuevamente.
            contactos = listaContactos.ToArray();

            return contactos;
        }



    }
}
