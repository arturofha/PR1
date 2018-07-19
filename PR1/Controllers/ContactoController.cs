using PR1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PR1.Controllers
{
    //
    [RoutePrefix("api/Contacto")]
    public class ContactoController : ApiController
    {
        Contacto[] contactos = new Contacto[]{
          new Contacto() { Id=1,Nombre="Leonel", Apellido="Messi"} ,
          new Contacto(){Id=2,Nombre="Cristiano",Apellido="Ronaldo"},
          new Contacto(){Id=3,Nombre="Luis",Apellido="Suarez" },
           new Contacto(){Id=3,Nombre="Andrés",Apellido="Iniesta" }
        };

        //Devolver una lista completa
        [Route("")]
        public IEnumerable<Contacto> Get()
        {
            return contactos;
        }

        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            // buscamos en la lista y obtenemos el primer id que encontremos
            Contacto ct = contactos.FirstOrDefault<Contacto>(x => x.Id == id);

            if (ct == null)
            {
                return NotFound();
            }

            return Ok(ct);
        }

        //metodo post para ingresar contactos
        
            [Route("")]
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

        [Route("{id:int}")]
        public IEnumerable<Contacto> Put(int id,[FromBody] Contacto contactoCambiado) {            

            for(int i = 0; i < contactos.Length; i++)
            {
                if(contactos[i].Id == id)
                {
                    contactos[i].Nombre = contactoCambiado.Nombre;
                    contactos[i].Apellido = contactoCambiado.Apellido;
                }
            }

            return contactos;
        }

       public IEnumerable<Contacto> Delete(int id) {

            //borramos la línea haciendo un select de todos menos el que tiene el id indicado
            contactos = contactos.Where<Contacto>(x => x.Id != id).ToArray<Contacto>();

            return contactos;
       }

        //podemos crear más acciones de tipo get poniendole el nombre "Get" al principio y luego el nombre que queramos
        //ésto es una opción de web api 1
        //también la opción de configurar el routing Template para agregarle el action
        //para usar web api routing de web api 2, usamos el Route("dirección/{parámetros}")
        [Route("buscaxGet/{valor}")]
        public IEnumerable<Contacto> GetContactoPorNombre(string valor)
        {
            Contacto[] contactArray = contactos.Where<Contacto>(x => x.Nombre.Contains(valor)).ToArray<Contacto>();
             return contactArray;
        }

        //en este ejemplo el route se lo ponemos manual y como el nombre no comienza con get le ponemos el verbo al inicio con  [HttpGet]
        [Route("busca/{valor}")]
        [HttpGet]
        public IEnumerable<Contacto> BuscarContactoPorNombre(string valor)
        {
            Contacto[] contactArray = contactos.Where<Contacto>(x => x.Nombre.Contains(valor)).ToArray<Contacto>();
            return contactArray;
        }
    }
}
