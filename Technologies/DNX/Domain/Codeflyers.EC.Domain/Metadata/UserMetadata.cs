using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace Codeflyers.EC.Domain.Metadata
{
    public class UserMetadata
    {
        [HiddenInput(DisplayValue = false)]
        public int UserId { get; set; }
    }

}
