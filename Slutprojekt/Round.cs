using System;

namespace Slutprojekt
{
    public class Round
    {
        protected int Hp;
        public bool Lead {get; set;}
        public bool Camo {get; set;}
        protected bool clearedRound;
        protected Random generator = new Random();

        public bool PlayRound(Player player1){
            if (player1.Damage < Hp)
            {
                player1.Health -= Hp - player1.Damage;
                System.Console.WriteLine("Du tappade " + (Hp-player1.Damage) + " liv");
            }

            if (player1.Health <= 0)
            {
                clearedRound = false;
                return clearedRound;
            }
            return true;
        }
    }
}
