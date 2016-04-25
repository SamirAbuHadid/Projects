using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MStrudel.Domain.Entities
{
	public class ProductImage
	{
		[HiddenInput(DisplayValue = false)]
		public int ImageID { get; set; }

		[HiddenInput(DisplayValue = false)]
		public int ProductID { get; set; }

		[HiddenInput(DisplayValue = false)]
		public byte[] ImageData { get; set; }

		[HiddenInput(DisplayValue = false)]
		public string ImageMimeType { get; set; }
	}
}
