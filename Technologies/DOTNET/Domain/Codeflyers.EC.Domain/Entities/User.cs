using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codeflyers.EC.Domain.Metadata;
using Codeflyers.EC.Domain.Validators;
using FluentValidation.Attributes;

namespace Codeflyers.EC.Domain.Entities
{
    [MetadataType(typeof(UserMetadata))]
    [Validator(typeof(UserValidator))]
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
