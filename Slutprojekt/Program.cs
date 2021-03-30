using System.Data.Common;
using System.ComponentModel;
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

            Dictionary<int, Action> roundsOrder = new Dictionary<int, Action>();
            roundsOrder.Add(0 , new Round());


            for (int i = 0; true; i++)
            {
                roundsOrder[i]
            }

            System.Console.ReadLine();
        }
    }
}
