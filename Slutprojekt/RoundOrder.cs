using System.CodeDom.Compiler;
using System;

namespace Slutprojekt
{
    public class RoundOrder : Round
    {

        bool lead {get; set;}
        bool camo {get; set;}
        
        public RoundOrder(int round){
            lead = GeneratedCodeAttribute.Next.Next(100) >= round;
            camo = GeneratedCodeAttribute.Next.Next(100) >= round;
        }
         
    }
}
