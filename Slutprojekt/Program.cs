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
            //Här skapas spelaren. Om man ska göra spelet till multiplayer hade det varit bra att göra en array eller lista med antalet spelare som spelar samtidigt.
            Player player1 = new Player();
            Round roundGenerator = new Round(1);
            int i = 1;

            //Skapar en rundaordning på 100 rundor med ens roundgenerator och lägger in i listan rounds. Detta borde göras i metoden
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
                player1.PrintMoney();
                player1.PrintMenu(i);

                System.Console.WriteLine();
                rounds[i-1].PrintRoundDamage();
                player1.PrintPlayerDamage();

                player1.Money = -player1.MenuChoise();

                System.Console.WriteLine("Total monkeys: " + player1.monkeys.Count);
                player1.UpdateDamage();

                player1.Health += rounds[i-1].PlayRound(player1);
                
                player1.Money = rounds[i-1].GivePlayerMoney(i);
                Console.Clear();
                i++;
            }

            System.Console.ReadLine();
        }
    }
}
