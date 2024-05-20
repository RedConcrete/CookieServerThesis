﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;

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
            if (_db.Players.Find(player.Id) == null)
            {
                _db.Players.Add(player);
                _db.SaveChanges();
                return CreatedAtAction("GetPlayer", new { id = player.Id }, player); //muss GetPlayer stehen ??? WHY
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
            Console.WriteLine($"Player {id} **********************************************************************************");
            Player player = _db.Players.Find(id);

            if (player == null)
            {
                return NotFound("Es gibt diesen Spieler nicht!");
            }
            return Ok(player);
        }

        [HttpPut]
        [Route("UpdatePlayer")]
        public IActionResult UpdatePlayer(Player player)
        {
            Console.WriteLine($"Player {player.Id} ---------------------------------------------------------------------------------");
            Player playerFromDB = _db.Players.Find(player.Id);

            if (playerFromDB == null)
            {
                return NotFound();
            }

            playerFromDB.UpdatePlayer(player);

            _db.SaveChanges();
            return Ok("Update player successfully");
        }
    }
}
