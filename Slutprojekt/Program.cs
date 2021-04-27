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

            Player player1 = new Player();

            RoundGenerator roundGenerator1 = new RoundGenerator();
            //Skapar en rundaordning på 100 rundor med ens roundgenerator och lägger in i listan rounds. 
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
            //Gameloopen, skriver ut menyn, tar emot menyvalet och spelar rundan. Uppdaterar också damage för jag gjorde allt på ett knasigt sätt.
            for (int i = 1; i < 101; i++)
            {
                player1.PrintMenu(i);
                player1.Money = -player1.MenuChoise(player1.Money);

                System.Console.WriteLine("Total monkeys: " + player1.monkeys.Count);
                player1.UpdateDamage();

                System.Console.WriteLine(player1.Damage + " " + player1.CamoDamage + " " + player1.LeadDamage);

                rounds[i-1].PlayRound(player1);
            }

            System.Console.ReadLine();
        }
    }
}
