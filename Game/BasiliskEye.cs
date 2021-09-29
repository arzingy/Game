using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class BasiliskEye:Artefact
    {
        public BasiliskEye(Person user,int power):base(user,power)
        {
            this.name = "Глаз василиска";
            this.User = user;
            this.power = 0;
        }
        public override void DoMagic(Person p, int power)
        {
            if (!p.Armor)
            {
                if (this.reusable)
                {
                    this.reusable = false;
                    if (p.State_ != Person.State.мертв)
                    {
                        p.State_ = Person.State.парализован;
                        p.Check_Abilities();
                    }
                }
            }
        }
    }
}
