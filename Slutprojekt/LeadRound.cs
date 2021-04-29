using System;

namespace Slutprojekt
{
    public class LeadRound : Round
    {
        public LeadRound(int i): base(i){
            this.hp = 100*i;
            this.LeadHp = (100*i)/2;
        }

        public override bool PlayRound(Player player1)
        {
            if (player1.Damage < hp)
            {
                player1.Health -= hp - player1.Damage;
                System.Console.WriteLine("Du tappade " + (hp-player1.Damage) + " liv");
            }

            else if (player1.Health <= 0)
            {
                clearedRound = false;
                return clearedRound;
            }
            return true;
        }
    }
}
