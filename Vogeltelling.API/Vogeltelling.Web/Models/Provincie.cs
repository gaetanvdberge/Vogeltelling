using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vogeltelling.Web.Models
{
    public class Provincie
    {
        [Key]
        public Guid RegionId { get; set; }

        public string RegionName { get; set; }

    }
}
