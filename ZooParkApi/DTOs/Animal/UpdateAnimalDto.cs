using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooParkApi.DTOs.Animal
{
    public class UpdateAnimalDto
    {
        public string Name { get; set; }
        public int? Count { get; set; }
    }
}
