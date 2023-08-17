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

        [HttpGet] // Most common type of HttpGet (GetAll)

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

        //api/taco?dorito=true
        //api/taco?SoftShell=true
        //api/taco?dorito=true&SoftShell=true
        [HttpGet("Filtered")]
        public List<Taco> GetFiltered(bool dorito = false, bool softShell = false) //optional params (bools need default values)
        {
            return dbContext.Tacos.Where(t =>t.Dorito == dorito && t.SoftShell == softShell).ToList();
        }

        
        [HttpPost]
        public Taco AddTaco(string name, float cost, bool softShell, bool dorito)
        {
            Taco t = new Taco();
            t.Name = name;
            t.Cost = cost;
            t.SoftShell = softShell;
            t.Dorito = dorito;
            dbContext.Tacos.Add(t);
            dbContext.SaveChanges();
            return t;
        }


        [HttpPatch("{Id}")]  // more for changing 1 parameter
        public Taco UpdatePrice(int Id, float price)
        {
            Taco t = dbContext.Tacos.FirstOrDefault(t => t.Id == Id);
            t.Cost = price;
            dbContext.Tacos.Update(t);  // change to a model that already exists
            dbContext.SaveChanges();

            return t;
        }


        [HttpPut]  // changes everything associated in the id
        public Taco ReplaceTaco(int id, [FromBody]Taco newTaco) // takes in a taco and replaces it with the associated id
        {
            Taco t = dbContext.Tacos.FirstOrDefault(t => t.Id == id);
            t.Id = id;
            t.Name = newTaco.Name;
            t.Cost = newTaco.Cost;
            t.SoftShell = newTaco.SoftShell;
            t.Dorito = newTaco.Dorito;

            dbContext.Tacos.Update(t);
            dbContext.SaveChanges();
            return t;
        }
    }
}
