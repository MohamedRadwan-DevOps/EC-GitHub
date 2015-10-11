using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Mvc;

namespace Codeflyers.EC.Domain.Metadata
{
    public class ProductMetadata
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }

        [DataType(DataType.MultilineText)]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
    }
}