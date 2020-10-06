
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessForensicsTest2.API.Client;
using BusinessForensicsTest2.DAL;
using BusinessForensicsTest2.Domain;
using BusinessForensicsTest2.Domain.Categories;
using BusinessForensicsTest2.Domain.Families;
using BusinessForensicsTest2.Domain.Species;
using Microsoft.AspNetCore.Mvc;

namespace BusinessForensicsTest2.API.Controllers
{
    [Route("api/[controller]")]
    public class AnimalController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly WikipediaClient _client;

        public AnimalController(IUnitOfWork unitOfWork, WikipediaClient client)
        {
            _unitOfWork = unitOfWork;
            _client = client;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var animals = _unitOfWork.AnimalRepository.GetAll();

            await FetchInfo(animals);

            return Ok(animals);

        }

        [HttpGet]
        [Route("GetByFamily/{family}")]
        public async Task<IActionResult> GetByFamily(string family)
        {
            if (string.IsNullOrWhiteSpace(family))
                return BadRequest("Invalid family input");

            return Ok(_unitOfWork.AnimalRepository.GetAllByFamily<Mammal>());
        }

        [HttpGet]
        [Route("Add/{animalName}")]
        public async Task<IActionResult> Add(string animalName)
        {
            if (string.IsNullOrWhiteSpace(animalName))
                return BadRequest("Animal name invalid");

            string description = await _client.GetAnimalDescription(animalName);
            string picture = await _client.GetPictureUrl(animalName);

            if (string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(picture))
                return BadRequest("Unable to find information about this animal");

            var animal = new
            {
                Name = animalName,
                Description = description,
                Picture = picture
            };

            return Ok(animal);
        }

        [HttpGet]
        [Route("GetDangerous")]
        public async Task<IActionResult> GetDangerous()
        {
            var dangerous = _unitOfWork.AnimalRepository.GetDangerous();
            await FetchInfo(dangerous);
            return Ok(dangerous);
        }

        private async Task FetchInfo(ICollection<Animal> animals)
        {
            foreach (var animal in animals)
            {
                animal.Description = await _client.GetAnimalDescription(animal.Name);
                animal.Picture = await _client.GetPictureUrl(animal.Name);
            }
        }
    }
}