using MStrudel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStrudel.Domain.Abstract
{
	public interface ICategoriesRepository
	{
		IEnumerable<Category> Categories { get; }
		void SaveCategory(Category category);
		void DeleteCategory(int categoryId);
	}
}
