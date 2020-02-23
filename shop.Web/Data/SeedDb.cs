using shop.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Web.Data
{
    public class SeedDb
    {

        private readonly DataContext context;
        private Random random;

        public SeedDb(DataContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            //aqui me dice que si la base de datos no esta creada
            //recordar , esto es Code First
            await this.context.Database.EnsureCreatedAsync();

            // aqui estoy preguntando si no hay datos en la base de datos, me meta productos en la base de datos
            if (!this.context.Products.Any())
            {
                this.AddProduct("Iphone z");
                this.AddProduct("Magic mouse");
                this.AddProduct("La veladora para ganar la carrera");
                // aqui le digo que me guarde los cambios, gracias al entiti framework
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name)
        {
            this.context.Products.Add(new Product
            {
                //aqui le estoy diciendo que el al nombre del producto me lo ponga un valor aleatorio
                Name = name,
                Price = this.random.Next(100),
                // si esta disponible, y cuantos hay en stock
                IsAvailabe = true,
                Stock = this.random.Next(100)
            });
        }

    }
}
