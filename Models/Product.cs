using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDynamicLinq.Models
{
    internal class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int State { get; set; }
        public int BrandId { get; set; }
    }
}
