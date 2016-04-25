using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MStrudel.Domain.Entities
{
	[Table("Category")]
	public class Category
	{
		[HiddenInput(DisplayValue = false)]
		public int CategoryId { get; set; }

		[Required(ErrorMessage="Введіть назву категорії")]
		[Display(Name="Назва")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Введіть порядок сортування")]
		[Display(Name = "Сортування (найменше перше)")]
		public int SortId { get; set; }
	}
}
