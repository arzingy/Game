using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
 public abstract class Artefact
    {
      public string name { get; set; }
      public Person User { get; set; }
      public bool reusable { get; set; }
      public  int power { get; set; }
        public Artefact(Person user,int power = 0)
        {
            this.reusable = true;
            this.power = power;
            this.User = user;
        }
        public abstract void DoMagic(Person p, int power);

    }
}
