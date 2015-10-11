using System.ComponentModel.DataAnnotations;
using Codeflyers.EC.Domain.Metadata;
using Codeflyers.EC.Domain.Validators;
using FluentValidation.Attributes;
namespace Codeflyers.EC.Domain.Entities
{
    [MetadataType(typeof(ProductMetadata))]
    [Validator(typeof(ProductValidator))]
    public class Product
    {
        public int ProductId { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public int RewardPoints { get; set; }
        public decimal Price { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}