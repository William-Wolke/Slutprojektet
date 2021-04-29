using System.Security.Cryptography;
using System;
using System.Collections.Generic;

namespace Slutprojekt
{
    public class Round
    {
        protected int hp;
        protected int LeadHp {get; set;}
        protected int CamoHp {get; set;}
        public bool Lead {get; set;}
        public bool Camo {get; set;}
        protected bool clearedRound;
        protected Random generator = new Random();

        public Round(int i){
            this.hp = 100*i;
        }
        //Spelar runda, virtual för att vanliga rundor ska ha mindre kod än lead och camo rundor.
        public virtual bool PlayRound(Player player1){
            if (player1.Damage < hp)
            {
                player1.Health -= hp - player1.Damage;
                System.Console.WriteLine("Du tappade " + (hp-player1.Damage) + " liv");
            }

            if (player1.Health <= 0)
            {
                clearedRound = false;
                return clearedRound;
            }
            return true;
        }
        //Ger spelaren pengar, man får 1 £ för varje ballong och sedan 100 + rundans tal så rund 14 får man 114 £.
        public int GivePlayerMoney(int i){
            return (this.hp + this.CamoHp + this.LeadHp + 100+i);
        }
        public int GenerateRound(int round){

            if (generator.Next(2) == 1)
            {
                Camo = generator.Next(100) <= round;
            }
            else
            {
                Lead = generator.Next(100) <= round;
            }

            if (this.Camo == true && this.Lead == true)
            {
                return 3;    
            }

            else if (this.Camo == false && this.Lead == true)
            {
                    return 2;
            }

            else if (this.Camo == true && this.Lead == false)
            {
                 return 1;   
            }
            
            else
            {
                 return 0;   
            }
        
        }
    }
}
