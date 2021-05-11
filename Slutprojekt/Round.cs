using System.Security.Cryptography;
using System;
using System.Collections.Generic;

namespace Slutprojekt
{
    public class Round
    {
        protected int hp;
        protected int leadHp;
        protected int camoHp;
        protected int damageTaken;
        protected bool lead;
        protected bool camo;
        protected Random generator = new Random();

        public Round(int i){
            this.hp = 100*i;
        }
        //Spelar denna runda, virtual för att vanliga rundor ska ha mindre kod än lead och camo rundor enklare att köra
        public virtual int PlayRound(Player player1){
            damageTaken = 0;
            //Kollar ifall rundans hp är större eller mindre än spelarens damage
            if (player1.Damage < hp)
            {
                damageTaken -= hp - player1.Damage;
                System.Console.WriteLine("Du tappade " + (hp-player1.Damage) + " liv");
            }
            return damageTaken;
        }
        //Ger spelaren pengar, man får 1 £ för varje ballong och sedan 100 + rundans tal så rund 14 får man 114 £ från att klara rundan.
        public int GivePlayerMoney(int i){
            return (this.hp + this.camoHp + this.leadHp + 100+i);
        }
        public int GenerateRound(int round){
            //slumpar om det blir en camo eller lead runda.
            if (generator.Next(2) == 1)
            {
                camo = generator.Next(100) <= round;
            }
            else
            {
                lead = generator.Next(100) <= round;
            }
            //kollar vilken typ av runda det blev, vänta dessa kan man bara ha i if-satsen ovan!
            if (this.camo == true && this.lead == true)
            {
                return 3;    
            }

            else if (this.camo == false && this.lead == true)
            {
                    return 2;
            }

            else if (this.camo == true && this.lead == false)
            {
                 return 1;   
            }
            
            else
            {
                 return 0;   
            }
        
        }
        //Skriver ut data till användaren.
        public void PrintRoundDamage(){
            System.Console.WriteLine("Normal bloons: " + this.hp + " Camo bloons: " + this.camoHp + " Lead bloons: " + this.leadHp);
        }
    }
}
