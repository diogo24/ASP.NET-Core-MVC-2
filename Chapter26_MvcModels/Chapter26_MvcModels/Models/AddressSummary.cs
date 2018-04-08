using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter26_MvcModels.Models
{
    [Bind(nameof(City))]
    public class AddressSummary
    {
        public string City { get; set; }

        [BindNever]
        public string Country { get; set; }
    }
}
