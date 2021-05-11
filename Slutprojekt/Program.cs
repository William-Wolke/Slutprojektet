using System.Data.Common;
using System;
using System.Collections.Generic;

namespace Slutprojekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till Blons Tower Text Defence");

            List<Round> rounds = new List<Round>();
            List<Player> player1Monkeys = new List<Player>(); 
            //Här skapas spelaren. Om man ska göra spelet till multiplayer hade det varit bra att göra en array eller lista med antalet spelare som spelar samtidigt.
            Player player1 = new Player();
            Round roundGenerator = new Round(1);
            int i = 1;
            player1Monkeys.Add(new Monkey());
            //Skapar en rundaordning på 100 rundor med ens roundgenerator och lägger in i listan rounds.
            for (int j = 0; j < 100; j++)
            {
                int l = roundGenerator.GenerateRound(j);
                switch (l){
                    case 0: 
                        rounds.Add(new Round(j));
                        break;
                    case 1: 
                        rounds.Add(new CamoRound(j));
                        break;
                    case 2: 
                        rounds.Add(new LeadRound(j));
                        break;
                    case 3: 
                        rounds.Add(new LeadCamoRound(j));
                        break;
                }
            }

            //Gameloopen, skriver ut menyn, tar emot menyvalet och spelar rundan. Uppdaterar också damage för jag gjorde allt på ett knasigt sätt.
            while (player1.Health > 0 && i < rounds.Count)
            {
                //Dessa skriver ut information till användaren
                player1.PrintMenu(i);
                System.Console.WriteLine();
                rounds[i-1].PrintRoundDamage();
                player1.PrintPlayerDamage();
                //Tar in användarinput
                player1.Money = -player1.MenuChoise();
                //Skriver ut hur många apor man har efter att man kanske köpt en.
                System.Console.WriteLine("Total monkeys: " + player1Monkeys.Count);
                player1Monkeys = player1.UpdateDamage(player1Monkeys);
                //Kollar ifall man klarat rundan och ger damage om man inte smällde alla bloons
                player1.Health += rounds[i-1].PlayRound(player1);
                //Ger spelaren pengar
                player1.Money = rounds[i-1].GivePlayerMoney(i);
                Console.Clear();
                i++;
            }

            System.Console.ReadLine();
        }

        
    }
}
