using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TacoBellAPILab.Models;

namespace TacoBellAPILab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkController : ControllerBase
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext();

        [HttpGet]

        public List<Drink> GetAll()
        {
            return dbContext.Drinks.ToList();
        }

        // api/Burrito/1
        [HttpGet("{Id}")]
        public Drink GetById(int Id)
        {
            return dbContext.Drinks.FirstOrDefault(b => b.Id == Id);
        }
    }
}
