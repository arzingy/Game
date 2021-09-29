using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
   public class Wizard:Person
    {
        int mana;
        List<Spell> LearntSpells { get; set; }
       
       public int Mana
        {
            get { return mana; }
            set { if (mana == 0) mana = value; }
        }
        public int CurrMana { get; set; }
        public Wizard(string aname, Race arace, Gender agender, int anage, int ahealth) :base( aname, arace,  agender, anage, ahealth)
        {
            CurrMana = 1000;
            Mana = 1000;
            LearntSpells = new List<Spell>();
        }
        public Wizard(string name, Race race, Gender gender,int age,int health,int mana) :base(name, race, gender,age,health)
        {
            Mana = mana;
            CurrMana = mana;
            LearntSpells = new List<Spell>();
        }

        public Wizard(): base()
        {
            CurrMana = 1000;
            Mana = 1000;
            LearntSpells = new List<Spell>();
        }

        public bool LearnNewSpell(Spell newspell)
        {
            bool learnt = false;
            if (LearntSpells.Contains(newspell))
                learnt = true;
            if (!learnt)
            {
                LearntSpells.Add(newspell);
                return true;
            }
            return false;
        }

        public bool ForgetSpell(Spell spellneededtobeforgotten)
        {
            if (LearntSpells.Contains(spellneededtobeforgotten))
                {
                    LearntSpells.Remove(spellneededtobeforgotten);
                    return true;
                }
            return false;
        }

        public bool DoSpell(Spell magicspell, Person p, int power)
        {
            if (this.State_ != Person.State.мертв)
            {
                if (LearntSpells.Contains(magicspell))
                {
                    magicspell.DoMagic(p, power);
                    return true;
                }
                return false;
            }
            else
                return false;
        }
        public override string ToString()
        {
            return base.ToString()+'\n' + 
                $"Мана: {CurrMana}\n";
           
        }
    }
}
