using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Game
{
    class ArmorSpell : Spell, IMagic
    {
        private Timer timer;
        public ArmorSpell(Wizard healer) : base(healer)
        {
            this.name = "Броня";
            this.MinMana = 50;
            this.Act_Speel = false;
            this.Cast_Speel = true;
        }
        public override void DoMagic(Person p, int power)
        {
            if (this.Speller.Talk && this.Speller.Act)
            {
                if (this.Speller.Talk)
                {
                    if (power % 30 != 0)
                        power = (power / 30) * 31;
                    if (power * 5 / 3 > (this.Speller).CurrMana)
                    {
                        power = (((this.Speller).CurrMana * 3 / 5) / 30) * 30;
                    }
                    (this.Speller).CurrMana -= power * 5 / 3;
                    timer = new Timer(power * 1000);
                    timer.Elapsed += OnTimerElapsed;
                    timer.AutoReset = false;
                    timer.Enabled = true;
                    p.Armor = true;
                }
            }
            void OnTimerElapsed(object sender, ElapsedEventArgs e)
            {
                Disaffect(p);
            }
        }

        private void Disaffect(Person p)
        {
            p.Armor = false;
        }
    }
}
