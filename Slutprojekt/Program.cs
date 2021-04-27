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

            RoundGenerator roundGenerator1 = new RoundGenerator();
            //Skapar en rundaordning på 100 rundor med ens roundgenerator och lägger in i listan rounds. Detta borde göras i metoden
            for (int i = 0; i < 100; i++)
            {
                roundGenerator1.NewRound(i);

                if (roundGenerator1.Camo == true && roundGenerator1.Lead == true)
                {
                    rounds.Add(new LeadCamoRound(i));
                }

                else if (roundGenerator1.Camo == true && roundGenerator1.Lead == false)
                {
                    rounds.Add(new CamoRound(i));
                }

                else if (roundGenerator1.Camo == false && roundGenerator1.Lead == true)
                {
                    rounds.Add(new LeadRound(i));
                }

                else
                {
                    rounds.Add(new Round(i));
                }               
            }
            //Gameloopen, skriver ut menyn, tar emot menyvalet och spelar rundan. Uppdaterar också damage för jag gjorde allt på ett knasigt sätt.
            for (int i = 1; i < 101; i++)
            {
                player1.PrintMoney();
                player1.PrintMenu(i);
                player1.Money = -player1.MenuChoise();

                System.Console.WriteLine("Total monkeys: " + player1.monkeys.Count);
                player1.UpdateDamage();

                System.Console.WriteLine(player1.Damage + " " + player1.CamoDamage + " " + player1.LeadDamage);

                rounds[i-1].PlayRound(player1);
                player1.Money = rounds[i-1].GivePlayerMoney(i);
            }

            System.Console.ReadLine();
        }
    }
}
