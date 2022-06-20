using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooParkApi.DAL;
using ZooParkApi.DTOs.Animal;
using ZooParkApi.Models;

namespace ZooParkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZooParkController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ZooParkController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("")]
        public IActionResult All()
        {
            return Ok(_context.Animals.Where(a=>a.IsDeleted == false));
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Animal animal = _context.Animals.Where(a=> a.IsDeleted==false && a.Id == id).SingleOrDefault();
            if (animal is null) return StatusCode(StatusCodes.Status404NotFound, new { statusCode=1050, message="This animal is not found in our zoo" });
            return Ok(animal);
        }
        [HttpPost]
        public IActionResult Create(CreateAnimalDto animalDto)
        {
            if (!ModelState.IsValid) return StatusCode(StatusCodes.Status400BadRequest, new { statusCode = 1090, message = "Please fill all values" });
            Animal animal = new Animal {
                Name = animalDto.Name,
                Count = animalDto.Count,
                CreatedTime = DateTime.Now,
                IsDeleted = false
            };
            _context.Animals.Add(animal);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateAnimalDto animalDto)
        {
            Animal animalDb = _context.Animals.Where(a=> a.IsDeleted == false && a.Id == id).FirstOrDefault();
            if (animalDb is null) return StatusCode(StatusCodes.Status404NotFound, new { statusCode = 1050, message = "This animal is not found in our zoo" });
            animalDb.Name = animalDto.Name ?? animalDb.Name;
            animalDb.Count = animalDto.Count?? animalDb.Count;
            //_context.Animals.Update(animalDb);
            _context.SaveChanges();
            return Ok(animalDb);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Animal animal = _context.Animals.Find(id);
            if (animal is null) return StatusCode(StatusCodes.Status404NotFound, new { statusCode = 1050, message = "This animal is not found in our zoo" });
            _context.Animals.Remove(animal);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
