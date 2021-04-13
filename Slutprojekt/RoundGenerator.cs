using System;

namespace Slutprojekt
{
    public class RoundGenerator : LeadCamoRound
    {
        public void NewRound(int round){

            if (generator.Next(2) == 1)
            {
                Camo = generator.Next(100) <= round;
            }
            else
            {
                Lead = generator.Next(100) <= round;
            }
        
        }
    }
}
