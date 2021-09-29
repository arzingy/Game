using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class DeathBootle : Artefact
    {

        public enum Size { s = 10, m = 25, l = 50 }
        public int Size_;
        public DeathBootle(Person user, int power, Size size) : base(user, power)
        {
            this.name = "Бутылка с мёртвой водой";
            this.User = user;
            this.power = 0;
            this.Size_ = Convert.ToInt32(size);
        }
        public override void DoMagic(Person w, int power)
        {
            if (w is Wizard)
            {
                if (this.reusable)
                {
                    this.reusable = false;
                    if ((w as Wizard).Mana - (w as Wizard).CurrMana < this.Size_)
                        (w as Wizard).CurrMana = (w as Wizard).Mana;
                    else
                        (w as Wizard).CurrMana += this.Size_;
                }
            }
        }
    }
}
