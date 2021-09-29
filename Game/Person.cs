using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Game
{
  public class Person : IComparable
    {
        public enum State{здоров,ослаблен,болен,отравлен,парализован,мертв}
        public enum Gender { мужской,женский}
        public enum Race { человек, гном, эльф, орк, гоблин }
        public List<Artefact> inventory { get; set; }
        public void GetArtefact(Artefact p)
        {
            if(p.reusable)
            inventory.Add(p);
        }
        public void ThrowArtefact(Artefact p)
        {
            if(inventory.Contains(p))
            inventory.Remove(p);
        }
        public bool UseArtefact(Artefact p, Person towho, int power)
        {
            if (this.State_ != Person.State.мертв)
            {
                if (inventory.Contains(p))
                {

                    p.DoMagic(towho, power);
                    if (!p.reusable)
                        this.inventory.Remove(p);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        
        }
        public void TransferArtefact(Artefact p,Person to)
        {
            if (this.inventory.Contains(p))
            {
                to.inventory.Add(p);
                this.inventory.Remove(p);
            }
        }

        private string name="";
        protected int ID { get; set; }
        static int lastId = 0;
        int health;
        public bool Act { get; set; }
        public bool Talk { get; set; }
       protected static int generateId()
        {
            return Interlocked.Increment(ref lastId);
        }

        public State State_ {
            get;
            set;
        }
       public Race Race_
        {
            get;
        }
        public Gender Gender_
        {
            get;
        }
        public string Name
        {
            get { return name; }
            set { if (name == "") name = value; }
        }
        public int Age { get; }
        public bool Armor { get; set; }
       public int CurrHealth { get; set; }
       public int Health
        {
            get { return health; }
            set { if (health == 0) health = value; }
        }
        int Exp { get; set; }
   public  Person()
        {
            this.Name = name;
            this.Age = 0;
            this.CurrHealth = 100;
            this.State_ = State.здоров;
            this.Race_= Race.человек;
            this.Gender_ = Gender.женский;
            this.ID = generateId();
            this.Health = 100;
            this.Armor = false;
            this.Act = true;
            this.Talk = true;
            this.inventory = new List<Artefact>();
        }
        public Person(string name, Race arace, Gender agender, int anage, int ahealth)
        {
            this.name = name;
           
            Race_ = arace;
            Gender_ = agender;
            Age = anage;
            CurrHealth = ahealth;
            Health = ahealth;
            inventory = new List<Artefact>();
            Armor = false;
            Act = true;
            Talk = true;
        }
        public void Check_Health()
        {
            if (CurrHealth == 0)
            {
                State_ = State.мертв;
            }
            else if (CurrHealth * 100.0 / Health < 10)
            {
                State_ = State.ослаблен;
            }
            else if (CurrHealth * 100.0 / Health >= 10)
            {
                State_ = State.здоров;
            }
        }
       public void Check_Abilities()
        {
            if(this.State_==State.здоров || this.State_ == State.ослаблен)
            {
                this.Act = true;
                this.Talk = true;
            }
            if(this.State_ == State.болен || this.State_==State.отравлен)
            {
                this.Act = false;
                this.Talk = true;
            }
            if(this.State_ == State.парализован || this.State_ == State.мертв)
            {
                this.Act = false;
                this.Talk = false;
            }
        }
       
        public override string ToString()
        {
            return $"Name: {Name}\n" +
                    $"ID: {ID}\n" +
                    $"State: {State_}\n" +
                    $"Race: {Race_}\n" +
                    $"Gender: {Gender_}\n" +
                    $"Age: {Age}\n" +
                    $"Max Health: {Health}\n" +
                    $"Current Health: {CurrHealth}\n" +
                    $"Experience: {Exp}";
        }
        public int CompareTo(object o)
        {
           Person character = o as Person;
            if (character == null)
                throw new Exception("Error");
            return this.Exp.CompareTo(character.Exp);
        }
    }
   
}
