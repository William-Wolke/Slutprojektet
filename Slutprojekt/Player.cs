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
        public int Money {get; set;}
        bool correctInput = false;
        int choiseInt;
        //Void metod som bara skriver ut menyn, mums
        public void PrintMenu(int i)
        {
            System.Console.WriteLine("Round " + i);

            System.Console.WriteLine("What do you want to do?");
            System.Console.WriteLine("Enter 0 for nothing");
            System.Console.WriteLine("Enter 1 to purchase Dartmonkey: 100£");
            System.Console.WriteLine("Enter 2 to purchase Ninjamonkey: 300£");
            System.Console.WriteLine("Enter 3 to purchase Bombtower: 300£");
            System.Console.WriteLine("Enter 4 to purchase Wizarmonkey: 600£");
        }
        //Här har jag valt att lägga varje menyval till separata spelare. Detta gör så att om man ska implementera multiplayer i spelet så kan varje spelare ha sitt eget menyval
        public int MenuChoise(int money)
        {
            correctInput = false;

            while (correctInput == false)
            {
                bool success = int.TryParse(Console.ReadLine(), out choiseInt);
                //Ifall användaren har skrivit in en int i överhuvudtaget
                if (success)
                {   //här är en switch med de utfall som man kan göra. och en if sats nedanför som tar upp om man inte har skrivit rätt nummer. FIck inte det att funka i switch.
                    switch(choiseInt){
                        case 1: 
                            if(money > 100){
                                monkeys.Add(new DartMonkey());
                                correctInput = true;
                                return 100;
                            }
                           break; 
                        case 2: 
                            if(money > 300){
                                monkeys.Add(new NinjaMonkey());
                                correctInput = true;
                                return 300;
                            }
                            break;
                            
                        case 3: 
                            if(money > 300){
                                monkeys.Add(new BombTower());
                                correctInput = true;
                                return 300;
                            }
                            break;
                            
                        case 4: 
                            if(money > 300){
                                monkeys.Add(new WizardMonkey());
                                correctInput = true;
                                return 600;
                            }
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
                else{ //ifall användaren skrev in text i nuffran
                    System.Console.WriteLine("Not a number, try again.");
                }

            }
            return choiseInt;
        }
        //Eftersom att jag inte fick subklasserna att direkt ändra på damage så fick jag göra en separat metod som uppdaterar skadan
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
