using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZooParkApi.DTOs.Animal
{
    public class CreateAnimalDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Count { get; set; }
    }
}
