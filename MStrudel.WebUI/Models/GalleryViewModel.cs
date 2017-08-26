using System.Collections.Generic;
using MStrudel.Domain.Entities;

namespace MStrudel.WebUI.Models
{
    public class GalleryViewModel
    {
        public IEnumerable<ProductImage> ProductImages { get; set; }
        public int ProductId { get; set; }
    }
}