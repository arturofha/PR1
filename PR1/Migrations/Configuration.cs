namespace PR1.Migrations
{
    using PR1.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PR1.Models.PR1Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //ESTE METODO ES LLAMADO CUANDO CREA O ACTUALIZA LA BD
        protected override void Seed(PR1.Models.PR1Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            context.Contactoes.AddOrUpdate(new Contacto[] { 
              new Contacto { Nombre = "Andrew",Apellido= "Peters" },
              new Contacto { Nombre = "Brice",Apellido= "Lambson" },
              new Contacto { Nombre = "Rowan",Apellido= "Miller" }
            });

        }
    }
}
