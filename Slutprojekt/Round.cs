using System;

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
        //Spelar runda, virtual för att vanliga rundor ska ha mindre kod än lead och camo rundor.

        public Round(int i){
            this.hp = 100*i;
        }

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
    }
}
