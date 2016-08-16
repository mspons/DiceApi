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
            // If sides weren't specified, default to six
            if (sides == 0) 
            {
                sides = 6;
            }

            // Negative number of sides is not allowed
            if (sides < 0) 
            {
                return this.BadRequest();
            }
            
            var die = new Die(sides);

            return this.Ok(die.Roll());
        }
    }
}