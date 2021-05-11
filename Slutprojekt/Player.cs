using System;
using System.Collections.Generic;

namespace Slutprojekt
{
    public class Player
    {
        //varje player har en lista med sina egna apor, ifall man skapar en muliplayer så kommer det överlätta att skilja vilka apor som tillhör vem. Däremot vore det nog bättre att organisera dessa i program.cs för att ha alla instanser på samma ställe.
        public List<Monkey> monkeys = new List<Monkey>();
        public int Damage { get; set; }
        public int LeadDamage { get; set; }
        public int CamoDamage { get; set; }
        public int Health { get; set; }
        public int Money {get; set;}

        public bool GameOver {get; set;}
        bool correctInput = false;
        int choiseInt;
        //Instansierar en ny spelare och ger den de viktiga värdena
        public Player(){
            this.Money = 150;
            this.GameOver = false;
            this.Health = 200;
        }
        //Void metod som bara skriver ut menyn, mums
        public void PrintMenu(int i)
        {
            System.Console.WriteLine("Round " + i);

            System.Console.WriteLine("What do you want to do? You have " + this.Money + " money");
            System.Console.WriteLine("Enter 0 for nothing");
            System.Console.WriteLine("Enter 1 to purchase Dartmonkey: 100$");
            System.Console.WriteLine("Enter 2 to purchase Ninjamonkey: 300$");
            System.Console.WriteLine("Enter 3 to purchase Bombtower: 300$");
            System.Console.WriteLine("Enter 4 to purchase Wizarmonkey: 600$");
        }

        //Här har jag valt att lägga varje menyval till separata spelare. Detta gör så att om man ska implementera multiplayer i spelet så kan varje spelare ha sitt eget menyval
        public int MenuChoise()
        {
            correctInput = false;

            while (correctInput == false)
            {
                bool success = int.TryParse(Console.ReadLine(), out choiseInt);
                //Ifall användaren har skrivit in en int i överhuvudtaget
                if (success)
                {   //här är en switch med de utfall som man kan göra. och en if sats nedanför som tar upp om man inte har skrivit rätt nummer. FIck inte det att funka i switch.
                    switch(choiseInt){
                        case 0:
                        correctInput = true;
                        break;

                        case 1: 
                            if(this.Money > 100){
                                monkeys.Add(new DartMonkey());
                                correctInput = true;
                                return 100;
                            }
                            else{
                                System.Console.WriteLine("Not enough funds");
                            }
                           break; 
                        case 2: 
                            if(this.Money > 300){
                                monkeys.Add(new NinjaMonkey());
                                correctInput = true;
                                return 300;
                            }
                            else{
                                System.Console.WriteLine("Not enough funds");
                            }
                            break;
                            
                        case 3: 
                            if(this.Money > 300){
                                monkeys.Add(new BombTower());
                                correctInput = true;
                                return 300;
                            }
                            else{
                                System.Console.WriteLine("Not enough funds");
                            }
                            break;
                            
                        case 4: 
                            if(this.Money > 300){
                                monkeys.Add(new WizardMonkey());
                                correctInput = true;
                                return 600;
                            }
                            else{
                                System.Console.WriteLine("Not enough funds");
                            }
                            break;
                            
                    }
                    //De här två kunde jag inte kontrollera med en switch så de görs med ifs
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
        //Skriver ut information till användaren.
        public void PrintPlayerDamage(){
            System.Console.WriteLine("Normal damage: " + this.Damage + " Camo damage: " + this.CamoDamage + " LeadDamage: " + this.LeadDamage);
        }
    }
}
