using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class StopParalysisSpell: Spell, IMagic
    {
        public StopParalysisSpell(Wizard healer) : base(healer)
        {
            this.name = "Отомри";
            this.MinMana = 85;
            this.Act_Speel = false;
            this.Cast_Speel = false;

        }
        public override void DoMagic(Person p, int power)
        {
            if (this.Speller.Talk && this.Speller.Act)
            {
                if (p.State_ == Person.State.парализован)
                {
                    var random = new Random();
                    if (random.Next(2) == 1)
                        p.State_ = Person.State.здоров;
                    else p.State_ = Person.State.ослаблен;
                    p.CurrHealth = 1;
                    (this.Speller).CurrMana -= 85;
                    p.Check_Abilities();
                }
            }
        }
    }
}
