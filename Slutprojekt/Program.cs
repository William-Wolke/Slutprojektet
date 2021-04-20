using System;
using System.Collections.Generic;

namespace Slutprojekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till Blons Tower Text Defence");

            List<Monkey> monkeys = new List<Monkey>();

            List<Round> rounds = new List<Round>();

            Player player1 = new Player();

            Dictionary<int, Action> monkeyMenu = new Dictionary<int, Action>();
            monkeyMenu.Add(1, monkeys.Add(new Monkey(1))); LÄgg till listan i player och ha metoder för att lägga till monkeys i player

            string buyMonkey;

            RoundGenerator roundGenerator1 = new RoundGenerator();

            for (int i = 0; i < 100; i++)
            {
                roundGenerator1.NewRound(i);

                if (roundGenerator1.Camo == true && roundGenerator1.Lead == true)
                {
                    rounds.Add(new LeadCamoRound());
                }

                else if (roundGenerator1.Camo == true && roundGenerator1.Lead == false)
                {
                    rounds.Add(new CamoRound());
                }

                else if (roundGenerator1.Camo == false && roundGenerator1.Lead == true)
                {
                    rounds.Add(new LeadRound());
                }

                else
                {
                    rounds.Add(new Round());
                }                
            }

            for (int i = 1; i < 101; i++)
            {
                System.Console.WriteLine("Round " + i);

                System.Console.WriteLine("Do you want to purchase a monkey?");
                System.Console.WriteLine("Enter 0 for no");
                System.Console.WriteLine("Enter 1 for Dartmonkey: 100£");
                System.Console.WriteLine("Enter 2 for Ninjamonkey: 300£");
                System.Console.WriteLine("Enter 3 for Wizarmonkey: 600£");

                buyMonkey = Console.ReadLine();
                bool success = int.TryParse(buyMonkey, out int boughtMonkey);

                if (success)
                {
                    
                }

                if ( boughtMonkey == 1)
                {
                    monkeys.Add(new Monkey());
                }
                else if ( boughtMonkey == 2)
                {
                    monkeys.Add(new Monkey());
                }
                else if ( boughtMonkey == 3)
                {
                    monkeys.Add(new Monkey());
                }

                rounds[i-1].PlayRound(player1);
            }

            System.Console.ReadLine();
        }
    }
}
