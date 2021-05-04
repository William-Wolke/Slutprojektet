using System;

namespace Slutprojekt
{
    public class LeadRound : Round
    {
        public LeadRound(int i): base(i){
            this.hp = 100*i;
            this.LeadHp = (100*i)/2;
        }

        public override int PlayRound(Player player1)
        {
            DamageTaken = 0;
            if (player1.Damage < hp)
            {
                DamageTaken -= hp - player1.Damage;
                System.Console.WriteLine("Du tappade " + (hp-player1.Damage) + " liv");
            }
            if (player1.LeadDamage < LeadHp)
            {
                DamageTaken -= hp - player1.LeadDamage;
                System.Console.WriteLine("Du tappade " + (hp-player1.Damage) + " liv");
            }
            return DamageTaken;
        }
    }
}
