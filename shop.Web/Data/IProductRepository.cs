using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Web.Data
{
    using Entities;

    // la interfaz de producto va a ser una implementacion de la interfaz generica pero con productos
    public interface IProductRepository : IGenericRepository<Product>
    {

        IQueryable GetAllWithUsers();
    }

}
