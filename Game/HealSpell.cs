using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class HealSpell : Spell, IMagic
    {
        public HealSpell(Wizard healer) : base(healer)
        {
            this.name = "Вылечить";
            this.MinMana = 20;
            this.Cast_Speel = true;
            this.Act_Speel = false;
        }
        public override void DoMagic(Person p, int power = 0)
        {
            if (this.Speller.Talk && this.Speller.Act)
            {
                if (this.Speller.Talk)
                {
                    if (p.State_ == Person.State.болен)
                    {
                        var random = new Random();
                        if (random.Next(2) == 1)
                            p.State_ = Person.State.здоров;
                        else p.State_ = Person.State.ослаблен;
                        (this.Speller).CurrMana -= 20;
                        p.Check_Abilities();
                    }
                }
            }
        }
    }
}
