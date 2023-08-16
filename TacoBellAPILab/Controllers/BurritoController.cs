using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TacoBellAPILab.Models;

namespace TacoBellAPILab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BurritoController : ControllerBase
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext();

        // api/Burrito
        [HttpGet]

        public List<Burrito> GetAll()
        {
            return dbContext.Burritos.ToList();
        }

        // api/Burrito/1
        [HttpGet("{Id}")]
        public Burrito GetById(int Id)
        {
            return dbContext.Burritos.FirstOrDefault(b => b.Id == Id);
        }

        // api/Burrito?name=Beefy 5 Layer
        [HttpPost]
        public Burrito AddBurrito(string name, float price, bool beans)
        {
            Burrito newBurrito = new Burrito();
            newBurrito.Name = name;
            newBurrito.Cost = price;
            newBurrito.Bean = beans;
            dbContext.Burritos.Add(newBurrito);
            dbContext.SaveChanges();

            return newBurrito;
        }


        // api/Burrito/Delete/1
        [HttpDelete("Delete/{Id}")]
        public Burrito DeleteBurrito(int Id)
        {
            Burrito b = dbContext.Burritos.FirstOrDefault(b => b.Id == Id);
            dbContext.Burritos.Remove(b);
            dbContext.SaveChanges();

            return b;
        }
    }
}