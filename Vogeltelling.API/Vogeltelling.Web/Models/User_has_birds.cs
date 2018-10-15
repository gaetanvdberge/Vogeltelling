using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vogeltelling.Web.Models
{
    public class User_has_birds
    {
        
        public string UserName { get; set; }
        public Guid BirdId { get; set; }

        [Key]
        public DateTime DateTime { get; set; }

        public Guid RegionId { get; set; }
        public Guid MomentId { get; set; }

    }
}
