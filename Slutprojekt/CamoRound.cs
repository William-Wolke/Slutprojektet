using System;

namespace Slutprojekt
{
    public class CamoRound : Round
    {
        public CamoRound(int i){
            this.hp = 100*i;
            this.CamoHp = (100*i)/2;
        }
        public override bool PlayRound(Player player1)
        {
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
    }
}
