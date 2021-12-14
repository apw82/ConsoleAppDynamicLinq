using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDynamicLinq.Models
{
    internal class BrandModelWithStats
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BrandStat BrandStat { get; set; }
    }
}
