using System.Data.Entity;
using MStrudel.Domain.Entities;

namespace MStrudel.Domain.Concrete
{
	public class EFDbContext : DbContext
	{
		static EFDbContext()
		{
			var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<ProductImage> ProductImages { get; set; }
	}
}
