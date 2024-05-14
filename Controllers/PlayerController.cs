using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerController : ControllerBase
    {

        private readonly ServerContext _db;

        public ServerController(ServerContext context)
        {
            _db = context;
        }


        [HttpPost]
        [Route("CreatePlayer")]
        public IActionResult CreatePlayer(Player player)
        {
            Console.WriteLine("CreatePlayer");
            if (_db.Players.Find(player.Id) == null)
            {
                _db.Players.Add(player);
                _db.SaveChanges();
                return CreatedAtAction("GetPlayer", new { id = player.Id }, player);
            }
            else
            {
                return Conflict("Ein Player mit dieser ID existiert bereits.");
            }
        }


        [HttpGet]
        [Route("GetPlayer")]
        public IActionResult GetPlayer(string id)
        {
            Console.WriteLine("GetPlayer");
            Player player = _db.Players.Find(id);

            if (player == null)
            {
                return NotFound("Es gibt diesen Spieler nicht!");
            }

            return Ok(player);
        }

        [HttpGet]
        [Route("GetCookies")]
        public IActionResult GetPlayerCurrentCookies(string id)
        {
            Console.WriteLine("GetPlayer");
            Player player = _db.Players.Find(id);

            if (player != null)
            {
                return Ok(player.Cookies);
            }
            else
            {
                return NotFound("Es gibt keinen Player!");
            }
        }
    }
}
