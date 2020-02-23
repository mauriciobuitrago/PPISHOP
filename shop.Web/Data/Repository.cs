using shop.Web.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Web.Data
{
	// la clase repositorio implementa la interfaz de repositorio
	public class Repository : IRepository
	{

		// aqui le estamos diciendo que me retorne los datos, aqui vamos a tener todos los metodos
		// por ejemplo en la clase product , que me retorne todo el crud
		//practicamente es el controlador, pero deuna forma global, que me sirva para otras clases
		private readonly DataContext context;

		public Repository(DataContext context)
		{
			this.context = context;
		}

		// IENUMERABLE es una lista instanciada, puede devolverse como cualquier lista
		public IEnumerable<Product> GetProducts()
		{
			// por favor retorneme la conexion a la base de datos,con la lista de productos, y por 
			//linq estamos ordenando los productos por el nombre
			//se llama expresion lamda p=>p.. la p es porque estamos hablando de products
			return this.context.Products.OrderBy(p => p.Name);
		}

		public Product GetProduct(int id)
		{
			// esta me devuelvo todos los productos que esten relacionados con el Id... 
			//recordar que este id es autoincremental gracias a entiti framework
			return this.context.Products.Find(id);
		}

		// para agregar un producto, a esa conexion de base de datos,.context
		//llevele el producto que estamos capturando
		public void AddProduct(Product product)
		{
			this.context.Products.Add(product);
		}

		public void UpdateProduct(Product product)
		{
			this.context.Update(product);
		}

		// a la coleccion de producto elimine este producto 
		public void RemoveProduct(Product product)
		{
			this.context.Products.Remove(product);
		}

		// ningun campo queda guardado si no se ejecuta este metodo, saveallAsync..
		//recordar que es un metodo asincrono,,, es decir que interfiere con la base de datos
		// y toma mas tiempo para ejecutarse.. todo metodo que modifique los datos de la base de datps
		//deberia ser asyncrono
		public async Task<bool> SaveAllAsync()
		{
			// todos los metodos asyncronos se recomienda que terminen en Async

			return await this.context.SaveChangesAsync() > 0;
			// este metodo nos devuelve la cantidad de registros modificados
			// si devuelve 0 es porque la transaccion no tuvo exito
		}

		// este metodo solo nos valida si el metodo existe o no
		// nos devuelve  un true si existe o un false si no existe
		public bool ProductExists(int id)
		{
			// busqueme el produto, y si el producto esta, devuelvame un true 
			return this.context.Products.Any(p => p.Id == id);
		}
	}
}
