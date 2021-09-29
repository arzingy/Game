using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Decoction:Artefact
    {
     public Decoction(Person user,int power ):base(user,power)
        {
            this.name = "Декокт из лягушачьих лапок";
            this.User = user;
            this.power = 0;
        }
        public override void DoMagic(Person p, int power)
        {
            if (this.reusable)
            {
                if (p.State_==Person.State.ослаблен)
                {
                    this.reusable = false;
                    p.State_ = Person.State.здоров;
                }
                p.Check_Abilities();
            }
        }
    }
}
