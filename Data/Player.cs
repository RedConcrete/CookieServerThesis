using System;
using System.Collections.Generic;

namespace Server.Data
{
    public class Player
    {
        public string Id { get; set; }
        // private string id; SQL Injektion
        public float Cookies { get; set; }
        public float Sugar { get; set; }
        public float Flour { get; set; }
        public float Eggs { get; set; }
        public float Butter { get; set; }
        public float Chocolate { get; set; }
        public float Milk { get; set; }

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

        public Boolean Buy(Player player, int amount, string resource, Market market)
        {
            switch (resource.ToLower())
            {
                case "sugar":
                    if (player.Cookies >= market.SugarPrice)
                    {
                        Sugar += amount;
                        player.Cookies = player.Cookies - market.SugarPrice * amount;
                        return true;
                        break;
                    }
                    else
                    {
                        return false;
                        break;
                    }
                case "flour":
                    if (player.Cookies >= market.FlourPrice)
                    {
                        Flour += amount;
                        player.Cookies = player.Cookies - market.FlourPrice * amount;
                        return true;
                        break;
                    }
                    else
                    {
                        return false;
                        break;
                    }
                case "eggs":
                    if (player.Cookies >= market.EggsPrice)
                    {
                        Eggs += amount;
                        player.Cookies = player.Cookies - market.EggsPrice * amount;
                        return true;
                        break;
                    }
                    else
                    {
                        return false;
                        break;
                    }
                case "butter":
                    if (player.Cookies >= market.ButterPrice)
                    {
                        Butter += amount;
                        player.Cookies = player.Cookies - market.ButterPrice * amount;
                        return true;
                        break;
                    }
                    else
                    {
                        return false;
                        break;
                    }
                case "chocolate":
                    if (player.Cookies >= market.ChocolatePrice)
                    {
                        Chocolate += amount;
                        player.Cookies = player.Cookies - market.ChocolatePrice * amount;
                        return true;
                        break;
                    }
                    else
                    {
                        return false;
                        break;
                    }
                case "milk":
                    if (player.Cookies >= market.MilkPrice)
                    {
                        Milk += amount;
                        player.Cookies = player.Cookies - market.MilkPrice * amount;
                        return true;
                        break;
                    }
                    else
                    {
                        return false;
                        break;
                    }
                default:
                    Console.WriteLine("Resource nicht gefunden.");
                    return false;
                    break;
            }
        }

        public Boolean Sell(Player player, int amount, string resource, Market market)
        {
            switch (resource.ToLower())
            {
                case "sugar":
                    if (player.Sugar >= amount)
                    {
                        Sugar -= amount;
                        player.Cookies = player.Cookies + market.SugarPrice * amount;
                        return true;
                        break;
                    }
                    else
                    {
                        return false;
                        break;
                    }
                case "flour":
                    if (player.Flour >= amount)
                    {
                        Flour -= amount;
                        player.Cookies = player.Cookies + market.FlourPrice * amount;
                        return true;
                        break;
                    }
                    else
                    {
                        return false;
                        break;
                    }
                case "eggs":
                    if (player.Eggs >= amount)
                    {
                        Eggs -= amount;
                        player.Cookies = player.Cookies + market.EggsPrice * amount;
                        return true;
                        break;
                    }
                    else
                    {
                        return false;
                        break;
                    }
                case "butter":
                    if (player.Butter >= amount)
                    {
                        Butter -= amount;
                        player.Cookies = player.Cookies + market.ButterPrice * amount;
                        return true;
                        break;
                    }
                    else
                    {
                        return false;
                        break;
                    }
                case "chocolate":
                    if (player.Chocolate >= amount)
                    {
                        Chocolate -= amount;
                        player.Cookies = player.Cookies + market.ChocolatePrice * amount;
                        return true;
                        break;
                    }
                    else
                    {
                        return false;
                        break;
                    }
                case "milk":
                    if (player.Milk >= amount)
                    {
                        Milk -= amount;
                        player.Cookies = player.Cookies + market.MilkPrice * amount;
                        return true;
                        break;
                    }
                    else
                    {
                        return false;
                        break;
                    }
                default:
                    Console.WriteLine("Resource nicht gefunden.");
                    return false;
                    break;
            }
        }
    }
}
