using System;

namespace Slutprojekt
{
    public class DartMonkey : Monkey
    {
        //Alla andra apor ärver ifrån dartmonkey eftersom att dartmonkey kastar projektiler mot en target så detta är ifall man vill expandera spelet ännu mer.
        public DartMonkey(){
            this.Damage = 100;
        }
    }
}
