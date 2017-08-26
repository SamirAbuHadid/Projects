using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace MStrudel.Domain.Entities
{
    [Table("ProductImages")]
    public class ProductImage
    {
        [Key]
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
