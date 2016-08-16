using Microsoft.AspNetCore.Mvc;
using DiceApi.Core;

namespace DiceApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class DieController : Controller
    {        
        // GET api/die
        [HttpGet]
        public IActionResult Get([FromQuery] int sides)
        {
            if (sides == 0) {
                sides = 6;
            }

            if (sides < 0) {
                return this.BadRequest();
            }
            
            var die = new Die(sides);

            return this.Ok(die.Roll());
        }
    }
}