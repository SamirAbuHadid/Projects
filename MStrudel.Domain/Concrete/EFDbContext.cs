using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MStrudel.Domain.Entities;

namespace MStrudel.Domain.Concrete
{
	public class EFDbContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<ProductImage> ProductImages { get; set; }
	}
}
