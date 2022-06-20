
using System;
using System.ComponentModel.DataAnnotations;

namespace ZooParkApi.Models
{
    public class Animal
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Count { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public DateTime CreatedTime { get; set; }
    }
}
