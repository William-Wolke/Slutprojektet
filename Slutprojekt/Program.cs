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

            for (int i = 0; i < 100; i++)
            {
                rounds[i].PlayRound(player1);


            }

            System.Console.ReadLine();
        }
    }
}
