using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace MStrudel.Domain.Entities
{
	[Table("Products")]
	[Bind(Exclude = "Category")]
	public class Product
	{
		[HiddenInput(DisplayValue = false)]
		public int ProductID { get; set; }

		[Required(ErrorMessage = "Будь ласка введіть назву")]
		[Display(Name = "Назва")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Будь ласка введіть опис")]
		[DataType(DataType.MultilineText)]
		[Display(Name = "Опис")]
		[MaxLength(500, ErrorMessage="Довжина опису повинна бути меншою за 500 символів")]
		public string Description { get; set; }

		[HiddenInput(DisplayValue = false)]
		[ForeignKey("Category")]
		public int CategoryId { get; set; }

		[Required]
		[Display(Name = "Ціна")]
		[Range(0.1, double.MaxValue, ErrorMessage = "Ціна повинна буди додатнім числом")]
		[DataType(DataType.Currency)]
		[DisplayFormat(ApplyFormatInEditMode = true)]
		[UIHint("currency")]
		public decimal Price { get; set; }

		[HiddenInput(DisplayValue = false)]
		public byte[] ImageData { get; set; }

		[HiddenInput(DisplayValue = false)]
		public string ImageMimeType { get; set; }

        public List<int> ImageIds { get; set; }

		[Display(Name = "Категорія")]
		[HiddenInput(DisplayValue = false)]
		public virtual Category Category { get; set; }
	}
}
