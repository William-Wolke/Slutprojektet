using System;

namespace Slutprojekt
{
    public class Round
    {
        protected int hp {get; set;}
        static Random generator = new Random();

        public Round(int i){
            hp = generator.Next(100) * i;
        }
    }
}
