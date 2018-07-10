#Practica 1 Web Apis

	ASP.NET Web Api<br />
Ejemplo de una Web Api de lista de Contactos <br/>

		Tiene acciones GET, PUT, DELETE, POST

		Para usar Entity Framework Code-first Migrations hicimos lo siguiente:

1. Aseguramos que esté carpeta App_Data 
2. En Package Manager Console ejecutamos: enable-migrations
3. Modificamos método Seed de Migrations\Configuration.cs 
4. En Package Manager Console ejecutamos: add-migration Initial 
5. En Package Manager Console ejecutamos: update-database -verbose