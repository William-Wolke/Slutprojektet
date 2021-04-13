using System;

namespace Slutprojekt
{
    public class Round
    {
        protected int Hp {get; set;}
        public bool Lead {get; set;}
        public bool Camo {get; set;}
        protected Random generator = new Random();

        public void PlayRound(Player player1){
            if (player1.Damage < Hp)
            {
                player1.Health -= Hp - player1.Damage;
                System.Console.WriteLine("Du tappade " + (Hp-player1.Damage) + " liv");
            }
        }
    }
}
