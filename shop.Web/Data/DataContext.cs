

namespace shop.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
	using shop.Web.Data.Entities;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	public class DataContext : IdentityDbContext<User>
	{// AQUI LE ESTAMOS DICIENDO QUE ME TRABAJE CON LAS TABLAS DE SEGURIDAD Y CON MI MODELO USER
		// creamos una propiedad de tipo Dbset para ver que modelo voy a tirar a la base de datos
		public DbSet<Product> Products { get; set; }
		// cada vez que necesite acceder a los productos , voy a accer a esta propiedad

		//con este contructor me pego a la base de datos ,recordar el string de conexion esta en appsetting.json
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}
	}

}
