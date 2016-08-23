using Microsoft.AspNetCore.Mvc;
using DiceApi.Core;

namespace DiceApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class DieController : Controller
    {   
        private IRollable Die { get; }

        public DieController(IRollable die) 
        {
            this.Die = die;
        }

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

            return this.Ok(this.Die.Roll(sides));
        }
    }
}