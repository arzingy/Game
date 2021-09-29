using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class LifeBootle : Artefact
    {
        public enum Size { s = 10, m = 25, l = 50 }
        public int Size_;
        public LifeBootle(Person user, int power, Size size) : base(user, power)
        {
            this.name = "Бутылка с живой водой";
            this.power = 0;
            this.User = user;
            this.Size_ = Convert.ToInt32(size);
            this.User = null;
        }
        public override void DoMagic(Person w, int power)
        {
            if (w.State_ != Person.State.мертв) {
                if (this.reusable)
                {
                    this.reusable = false;
                    if (w.Health - w.CurrHealth < this.Size_)
                        w.CurrHealth = w.Health;
                    else
                        w.CurrHealth += this.Size_;
                    w.Check_Health();
                    w.Check_Abilities();
                }
            }
        }
    }
}
