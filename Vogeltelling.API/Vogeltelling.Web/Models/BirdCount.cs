using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vogeltelling.Web.Models
{
    public class BirdCount
    {
        public Bird Vogel { get; set; }

        public int AllRegions { get; set; }

        public int OVL { get; set; }
        public int WVL { get; set; }
        public int VB { get; set; }
        public int BRUS { get; set; }
        public int ANT { get; set; }
        public int LIM { get; set; }




    }
}
