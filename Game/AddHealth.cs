using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class AddHealth:Spell,IMagic
    {
        public AddHealth(Wizard healer) : base(healer) {
            this.name = "Добавить здоровье";
            this.MinMana = 2;
            this.Act_Speel = false;
            this.Cast_Speel = true;
        }

        public override void DoMagic(Person p, int power)
        {
            if (this.Speller.Talk && this.Speller.Act)
            {
                if (this.Speller.Act)
                {
                    if (power > p.Health - p.CurrHealth)
                    {
                        power = p.Health - p.CurrHealth;
                    }
                    if (power > (this.Speller).CurrMana / 2)
                    {
                        power = (this.Speller).CurrMana / 2;
                    }
                    p.CurrHealth += power;
                    (this.Speller).CurrMana -= power * 2;
                    p.Check_Health();
                    p.Check_Abilities();
                }
            }
        }
    }
 }

