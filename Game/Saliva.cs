using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Saliva:Artefact
    {
        public Saliva(Person user, int power) : base(user, power) {
            this.name = "Ядовитая слюна";
            this.power = power;
            this.User = user;
        }
        public override void DoMagic(Person p, int power)
        {
            if (!p.Armor)
            {
                if (p.State_ == Person.State.здоров || p.State_ == Person.State.ослаблен)
                {
                    if (p.CurrHealth == 1)
                    {
                        p.CurrHealth = 0;
                        p.State_ = Person.State.мертв;
                    }
                    else
                    {
                        p.State_ = Person.State.отравлен;
                        p.CurrHealth -= 1;
                        
                    }
                    p.Check_Abilities();
                }
            }
        }
    }
}
