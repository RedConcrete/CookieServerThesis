using System;
using System.Collections.Generic;

namespace Server.Data
{
    public class Player
    {
        public string Id { get; set; }
        // private string id; SQL Injektion
        public int Cookies { get; set; }
        public int Sugar { get; set; }
        public int Flour { get; set; }
        public int Eggs { get; set; }
        public int Butter { get; set; }
        public int Chocolate { get; set; }
        public int Milk { get; set; }

        public Player()
        {
        }

        public void UpdatePlayer(Player player)
        {
            this.Cookies = player.Cookies;
            this.Sugar = player.Sugar;
            this.Flour = player.Flour;
            this.Eggs = player.Eggs;
            this.Butter = player.Butter;
            this.Chocolate = player.Chocolate;
            this.Milk = player.Milk;
        }

        public Boolean Buy(int amount, string resource, Market market)
        {
            switch (resource.ToLower())
            {
                case "sugar":
                    Sugar += amount;
                    Cookies = Cookies - market.SugarPrice;
                    return true;
                    break;
                case "flour":
                    Flour += amount;
                    Cookies = Cookies - market.FlourPrice;
                    return true;
                    break;
                case "eggs":
                    Eggs += amount;
                    Cookies = Cookies - market.EggsPrice;
                    return true;
                    break;
                case "butter":
                    Butter += amount;
                    Cookies = Cookies - market.ButterPrice;
                    return true;
                    break;
                case "chocolate":
                    Chocolate += amount;
                    Cookies = Cookies - market.ChocolatePrice;
                    return true;
                    break;
                case "milk":
                    Milk += amount;
                    Cookies = Cookies - market.MilkPrice;
                    return true;
                    break;
                default:
                    Console.WriteLine("Resource nicht gefunden.");
                    return false;
                    break;
            }
        }

        public Boolean Sell(int amount, string resource, Market market)
        {
            switch (resource.ToLower())
            {
                case "sugar":
                    Sugar -= amount;
                    Cookies += market.SugarPrice;
                    return true;
                    break;
                case "flour":
                    Flour -= amount;
                    Cookies += market.FlourPrice;
                    return true;
                    break;
                case "eggs":
                    Eggs -= amount;
                    Cookies += market.EggsPrice;
                    return true;
                    break;
                case "butter":
                    Butter -= amount;
                    Cookies += market.ButterPrice;
                    return true;
                    break;
                case "chocolate":
                    Chocolate -= amount;
                    Cookies += market.ChocolatePrice;
                    return true;
                    break;
                case "milk":
                    Milk -= amount;
                    Cookies += market.MilkPrice;
                    return true;
                    break;
                default:
                    Console.WriteLine("Resource nicht gefunden.");
                    return false;
                    break;
            }
        }
    }
}
