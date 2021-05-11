using System;

namespace Slutprojekt
{
    public class LeadCamoRound : LeadRound
    {
        public LeadCamoRound(int i): base(i){
            this.hp = 100*i;
            this.camoHp = (100*i)/2;
            this.leadHp = (100*i)/2;
        }
        //Spelar just denna runda
        public override int PlayRound(Player player1)
        {
            damageTaken = 0;
            //Kollar ifall rundans hp är större eller mindre än spelarens damage
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
            if (player1.LeadDamage < leadHp)
            {
                damageTaken -= hp - player1.LeadDamage;
                System.Console.WriteLine("Du tappade " + (hp-player1.Damage) + " liv");
            }
            return damageTaken;
        }
        
    }
}
