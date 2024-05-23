using System;
using System.Collections.Generic;

namespace Server.Data
{
    public class Player
    {
        public string Id { get; set; }
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

        public void Buy(int amount, string resource)
        {
            switch (resource.ToLower())
            {
                case "sugar":
                    Sugar += amount;
                    break;
                case "flour":
                    Flour += amount;
                    break;
                case "eggs":
                    Eggs += amount;
                    break;
                case "butter":
                    Butter += amount;
                    break;
                case "chocolate":
                    Chocolate += amount;
                    break;
                case "milk":
                    Milk += amount;
                    break;
                default:
                    Console.WriteLine("Resource nicht gefunden.");
                    break;
            }
        }

        public void Sell(int amount, string resource)
        {
            switch (resource.ToLower())
            {
                case "sugar":
                    Sugar -= amount;
                    break;
                case "flour":
                    Flour -= amount;
                    break;
                case "eggs":
                    Eggs -= amount;
                    break;
                case "butter":
                    Butter -= amount;
                    break;
                case "chocolate":
                    Chocolate -= amount;
                    break;
                case "milk":
                    Milk -= amount;
                    break;
                default:
                    Console.WriteLine("Resource nicht gefunden.");
                    break;
            }
        }
    }
}
