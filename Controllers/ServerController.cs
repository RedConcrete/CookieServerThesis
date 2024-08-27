using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;
using System.Numerics;
using System.Collections;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;

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
            // Console.WriteLine($"Player {id} **********************************************************************************");
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
            // Console.WriteLine($"Player {player.Id} ---------------------------------------------------------------------------------");
            Player playerFromDB = _db.Players.Find(player.Id);

            if (playerFromDB == null)
            {
                return NotFound();
            }

            playerFromDB.UpdatePlayer(player);

            _db.SaveChanges();
            return Ok("Update player successfully");
        }

        [HttpGet]
        [Route("GetMarket")]
        public IActionResult GetMarket(int amountToGet)
        {

            List<Market> marketList = _db.Markets
                                .OrderByDescending(m => m.Date)
                                .Take(amountToGet)
                                .ToList();

            if (marketList == null)
            {
                return NotFound("Marktinformationen nicht gefunden!");
            }
            return Ok(marketList);

        }

        [HttpPost]
        [Route("Buy")]
        public IActionResult Buy(MarketRequest marketRequest)
        {
            List<KVN> kvn = _db.KVN
                                .OrderByDescending(m => m.Date)
                                .Take(1)
                                .ToList();

            return DoMarketAction("buy", marketRequest, kvn[0]);
        }

        [HttpPost]
        [Route("Sell")]
        public IActionResult Sell(MarketRequest marketRequest)
        {
            List<KVN> kvn = _db.KVN
                                .OrderByDescending(m => m.Date)
                                .Take(1)
                                .ToList();

            return DoMarketAction("sell", marketRequest, kvn.First());
        }

        private IActionResult DoMarketAction(string action, MarketRequest marketRequest, KVN kvn)
        {
            List<Market> marketList = _db.Markets
                                .OrderByDescending(m => m.Date)
                                .Take(1)
                                .ToList();

            Player player = _db.Players.Find(marketRequest.player);
            if (player != null)
            {
                if (action == "sell")
                {
                    if (player.Sell(player, marketRequest.amount, marketRequest.rec, marketList.First()))
                    {
                        player.UpdatePlayer(player);
                        kvn.addKVs(false, marketRequest.rec, marketRequest.amount);
                        _db.SaveChanges();
                        return Ok(player);
                    }
                    else
                    {
                        return Conflict("nicht genug Zutaten");
                    }
                }
                else
                {
                    if (player.Buy(player, marketRequest.amount, marketRequest.rec, marketList.First()))
                    {
                        player.UpdatePlayer(player);
                        kvn.addKVs(true, marketRequest.rec, marketRequest.amount);
                        _db.SaveChanges();
                        return Ok(player);
                    }
                    else
                    {
                        return Conflict("nicht genug Cookies");
                    }
                }
            }
            else
            {
                return Conflict("Dieser Spieler Exestiert nicht");
            }
        }
    }
}
