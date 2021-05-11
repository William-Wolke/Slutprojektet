using System;
using System.Collections.Generic;

namespace Slutprojekt
{
    public class Player
    {
        //varje player har en lista med sina egna apor, ifall man skapar en muliplayer så kommer det överlätta att skilja vilka apor som tillhör vem. Däremot vore det nog bättre att organisera dessa i program.cs för att ha alla instanser på samma ställe.
        //public List<Monkey> monkeys = new List<Monkey>();
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
            //Man kommer inte ur loopen tills man skrivit en siffra mellan 0 och 4
            while (correctInput == false)
            {
                bool success = int.TryParse(Console.ReadLine(), out choiseInt);
                //Ifall användaren har skrivit in en int i överhuvudtaget
                if (success)
                {   //här är en switch med de utfall som man kan göra. och en if sats nedanför som tar upp om man inte har skrivit rätt nummer. FIck inte det att funka i switch.
                    switch(choiseInt){
                        //Ifall användaren inte vill göra något
                        case 0:
                        correctInput = true;
                        break;
                    //Användaren köper en dartmonkey
                        case 1: 
                            if(this.Money > 100){
                                //monkeys.Add(new DartMonkey());
                                correctInput = true;
                                return 1;
                            }
                            else{
                                System.Console.WriteLine("Not enough funds");
                            }
                           break; 
                        //användaren köper en ninjamonkey
                        case 2: 
                            if(this.Money > 300){
                                //monkeys.Add(new NinjaMonkey());
                                correctInput = true;
                                return 2;
                            }
                            else{
                                System.Console.WriteLine("Not enough funds");
                            }
                            break;
                        //Användaren köper ett bombtorn
                        case 3: 
                            if(this.Money > 300){
                                //monkeys.Add(new BombTower());
                                correctInput = true;
                                return 3;
                            }
                            else{
                                System.Console.WriteLine("Not enough funds");
                            }
                            break;
                        //Användaren köper en wizardmonkey
                        case 4: 
                            if(this.Money > 600){
                                //monkeys.Add(new WizardMonkey());
                                correctInput = true;
                                return 4;
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
        //Köper en apa och lägger till den i listan och skickar tillbaks den.
        public List<Player> BuyMonkey(int i, List<Player> player1Monkeys){
            switch(i){
                case 1: player1Monkeys.Add(new DartMonkey());
                this.Money -= 100;
                break;

                case 2: player1Monkeys.Add(new NinjaMonkey());
                this.Money -= 300;
                break;

                case 3: player1Monkeys.Add(new BombTower());
                this.Money -= 300;
                break;

                case 4: player1Monkeys.Add(new WizardMonkey());
                this.Money -= 600;
                break;
            }

            return player1Monkeys;
        }
        //Eftersom att jag inte fick subklasserna att direkt ändra på damage så fick jag göra en separat metod som uppdaterar skadan
        public List<Player> UpdateDamage(List<Player> player1Monkeys){
            this.Damage = 0;
            this.CamoDamage = 0;
            this.LeadDamage = 0;
                for (int i = 0; i < player1Monkeys.Count; i++)
                {
                    this.Damage += player1Monkeys[i].Damage;
                    this.CamoDamage += player1Monkeys[i].CamoDamage;
                    this.LeadDamage += player1Monkeys[i].LeadDamage;
                }
            return player1Monkeys;
        }
        //Skriver ut information till användaren.
        public void PrintPlayerDamage(){
            System.Console.WriteLine("Normal damage: " + this.Damage + " Camo damage: " + this.CamoDamage + " LeadDamage: " + this.LeadDamage);
        }
    }
}
