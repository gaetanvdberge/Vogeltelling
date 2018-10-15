using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vogeltelling.Web.Models
{
    public class Moments
    {
        [Key]
        public Guid MomentId { get; set; }

        public DateTime Start { get; set; }

        public DateTime Stop { get; set; }
    }
}