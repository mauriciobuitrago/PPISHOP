using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Web.Data.Entities
{
	public class OrderDetailTemp : IEntity
	{
		public int Id { get; set; }

		[Required]
		public User User { get; set; }

		// aui le estamos diciendo que esta tabla tiene una relacion con product  y con user
		[Required]
		public Product Product { get; set; }

		//yo tengo este precio aqui para ver a como se vendio este producto... es algo temporal para mantener el precio
		[DisplayFormat(DataFormatString = "{0:C2}")]
		public decimal Price { get; set; }

		[DisplayFormat(DataFormatString = "{0:N2}")]
		public double Quantity { get; set; }

		// aqui es el valor calculado por los articulos que tenga
		[DisplayFormat(DataFormatString = "{0:C2}")]
		public decimal Value { get { return this.Price * (decimal)this.Quantity; } }
	}

}
