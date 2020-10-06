
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessForensicsTest2.Domain;
using BusinessForensicsTest2.Domain.Species;
using Microsoft.AspNetCore.Mvc;

namespace BusinessForensicsTest2.API.Controllers
{
    [Route("Animal")]
    public class AnimalController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAnimals()
        {
            return Ok(new Dog());
        }
    }
}