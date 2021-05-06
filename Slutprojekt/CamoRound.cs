using System;

namespace Slutprojekt
{
    public class CamoRound : Round
    {
        public CamoRound(int i): base(i){
            this.hp = 100*i;
            this.camoHp = (100*i)/2;
        }
        public override int PlayRound(Player player1)
        {
            damageTaken = 0;
            if (player1.Damage < hp)
            {
                damageTaken -= hp - player1.Damage;
                System.Console.WriteLine("Du tappade " + (hp-player1.Damage) + " liv");
            }
            if (player1.CamoDamage < camoHp)
            {
                damageTaken -= hp - player1.Damage;
                System.Console.WriteLine("Du tappade " + (hp-player1.Damage) + " liv");
            }
            return damageTaken;
        }
    }
}
