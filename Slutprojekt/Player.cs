using System;
using System.Collections.Generic;

namespace Slutprojekt
{
    public class Player
    {
        public int Damage { get; set; }
        public List<Monkey> monkeys = new List<Monkey>();
        public int LeadDamage { get; set; }
        public int CamoDamage { get; set; }
        public int Health { get; set; }
        bool correctInput = false;
        int choiseInt;

        public void PrintMenu(int i)
        {
            System.Console.WriteLine("Round " + i);

            System.Console.WriteLine("What do you want to do?");
            System.Console.WriteLine("Enter 0 for nothing");
            System.Console.WriteLine("Enter 1 to purchase Dartmonkey: 100£");
            System.Console.WriteLine("Enter 2 to purchase Ninjamonkey: 300£");
            System.Console.WriteLine("Enter 3 to purchase Wizarmonkey: 600£");
        }

        public int MenuChoise(string choise)
        {
            correctInput = false;

            while (correctInput == false)
            {
                bool success = int.TryParse(choise, out choiseInt);

                if (success)
                {
                    switch(choiseInt){
                        case 1: 
                            monkeys.Add(new Monkey());
                            correctInput = true;
                            break;
                        case 2: 
                            monkeys.Add(new Monkey());
                            correctInput = true;
                            break;
                        case 3: 
                            monkeys.Add(new Monkey());
                            correctInput = true;
                            break;
                    }

                    if (choiseInt < 0)
                    {
                        System.Console.WriteLine("Your number was too low");
                    }
                    else if (choiseInt > 3)
                    {
                        System.Console.WriteLine("Your number was too high");
                    }
                }

            }
            return choiseInt;
        }
    }
}
