using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Game
{
    public abstract class Spell:IMagic
    {
        public int power { get; set; }
        public Wizard Speller { get; set; }
        public int MinMana { get; set; }
        public bool Cast_Speel { set; get; }
        public bool Act_Speel { set; get; }
        public string name { set; get; }
        public Spell(Wizard speller)
        {
            this.Speller = speller;
            this.power = 0;
        }
        public abstract void DoMagic(Person p = null, int power = 0);
    }
}
