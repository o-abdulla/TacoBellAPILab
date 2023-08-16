using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TacoBellAPILab.Models;

namespace TacoBellAPILab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacoController : ControllerBase
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext();

        [HttpGet]

        public List<Taco> GetAll()
        {
            return dbContext.Tacos.ToList();
        }

        // api/Burrito/1
        [HttpGet("{Id}")]
        public Taco GetById(int Id)
        {
            return dbContext.Tacos.FirstOrDefault(b => b.Id == Id);
        }

        [HttpPatch("{Id}")]
        public Taco UpdateAge(int Id, float price)
        {
            Taco t = dbContext.Tacos.FirstOrDefault(t => t.Id == Id);
            t.Cost = price;
            dbContext.Tacos.Update(t);  // change to a model that already exists
            dbContext.SaveChanges();

            return t;
        }
    }


}
