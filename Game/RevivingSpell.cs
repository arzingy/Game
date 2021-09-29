using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class RevivingSpell:Spell,IMagic
    {
        public RevivingSpell(Wizard healer) : base(healer)
        {
            this.name = "Оживить";
            this.MinMana = 150;
            this.Act_Speel = true;
            this.Cast_Speel = true;
        }
        public override void DoMagic(Person p,int power)
        {
            if (this.Speller.CurrMana >= this.MinMana)
            {
                if (this.Speller.Talk && this.Speller.Act)
                {
                    if (p.State_ == Person.State.мертв)
                    {
                        var random = new Random();
                        if (random.Next(2) == 1)
                            p.State_ =Person.State.здоров;
                        else p.State_ = Person.State.ослаблен;
                        p.CurrHealth = 1;
                        (this.Speller).CurrMana -= 150;
                        p.Check_Abilities();
                    }
                }
            }
        }
    }
}
