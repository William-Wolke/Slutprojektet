using System;
using System.Collections.Generic;

namespace Slutprojekt
{
    public class Player
    {
        public List<Monkey> monkeys = new List<Monkey>();
        public int Damage { get; set; }
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
                            monkeys.Add(new DartMonkey());
                            correctInput = true;
                            break;
                        case 2: 
                            monkeys.Add(new NinjaMonkey());
                            correctInput = true;
                            break;
                        case 3: 
                            monkeys.Add(new WizardMonkey());
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

        public void UpdateDamage(){
            this.Damage = 0;
            this.CamoDamage = 0;
            this.LeadDamage = 0;
                for (int i = 0; i < monkeys.Count; i++)
                {
                    this.Damage += monkeys[i].Damage;
                    this.CamoDamage += monkeys[i].CamoDamage;
                    this.LeadDamage += monkeys[i].LeadDamage;
                }
                
        }
    }
}
