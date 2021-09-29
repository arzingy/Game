using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Stick:Artefact
    {
        int MaxPower { get; set; }
        public Stick(Person user,int power,int maxpower) : base(user,power)
        {
            this.name = "Посох-молния";
            this.User = user;
            this.power = power;
            this.MaxPower = maxpower;
        }
        public override void DoMagic(Person p,int powery)
        {
            if (!p.Armor)
            {
                if (p.State_ != Person.State.мертв)
                {
                    if (this.reusable)
                    {
                        if (MaxPower < powery)
                            powery = MaxPower;
                        if (p.CurrHealth < powery)
                            powery = p.CurrHealth;
                        power -= powery;
                        p.CurrHealth -= powery;
                        p.Check_Health();
                        p.Check_Abilities();
                    }
                    if (MaxPower == 0)
                        this.reusable = false;
                }
            }
        }
    }
}
