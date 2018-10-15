using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vogeltelling.Web.Models
{
    public class Bird
    {

        //[ScaffoldColumn(false)]
        //[Key]
        [Required]
        public Guid BirdId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string PhotoUrl { get; set; }


    }
}