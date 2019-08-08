using System;

namespace wns
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Angelo = new Human("Angelo");
            Wizzard Bob = new Wizzard("Bob");
            Ninja Jake = new Ninja("Jake");
            Samurai Mike = new Samurai("Mike");

            Jake.Attack(Angelo);
            Angelo.getStats();
            Jake.Attack(Angelo);
            Angelo.getStats();
            Mike.Meditate();
            Mike.getStats();
            Angelo.Attack(Mike);
            Mike.getStats();
            Mike.Meditate();
            Mike.getStats();


        }
    }
    class Human
    {

        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        protected int health;

         
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
         
        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }
         
        public Human(string name, int str, int intel, int dex, int hp)
        {
            Name = name;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            health = hp;
        }
         
        // Build Attack method
        public virtual int Attack(Human target)
        {
            int dmg = Strength * 3;
            target.health -= dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.health;
        }
        public virtual void getStats()
        {
            System.Console.WriteLine("************************************************************************************************************");
            System.Console.WriteLine($"Name: {Name}");
            System.Console.WriteLine($"Strength: {Strength}");
            System.Console.WriteLine($"Intelligence: {Intelligence}");
            System.Console.WriteLine($"Dexterity: {Dexterity}");
            System.Console.WriteLine($"Health: {health}");

        }
    }
    class Wizzard : Human
    {
        public Wizzard(string name) : base (name)
        {
            Intelligence = 25;
            health = 50;
        }
        
        public override int Attack(Human target)
        {
            int dmg = - 5;
            target.Intelligence += dmg;
            health += 5; 
            System.Console.WriteLine($"{Name} lowered {target.Name} intelligence by {dmg} for {health} health!");
            return target.Intelligence;
        }
        
        public int Heal(Human target)
        {
            target.Health += 10;
            return target.Health;
        }

        public override void getStats()
        {
            base.getStats();
        }
    }
    class Ninja : Human
    {
        public Ninja(string name) : base (name)
        {
            Dexterity = 175;
        }
        public override int Attack(Human target)
        {
            Random rand = new Random();
            int luckyDmg = rand.Next(1,6);
            int dmg = - 5;
            if(luckyDmg == 1)
            {
                target.Health -= 10;
                System.Console.WriteLine($"{Name} lowered {target.Name} health by 10!!!!");
                return target.Health;
            }
            target.Dexterity += dmg;
            System.Console.WriteLine($"{Name} lowered {target.Name} dexterity by {dmg}!");
            return target.Dexterity;
        }

        public int steal(Human target)
        {
            target.Health -= 5;
            health += 5;

            return target.Health ;
        }

        public override void getStats()
        {
            base.getStats();
        }
  
        
    }
    class Samurai : Human
    {
        public Samurai(string name) : base (name)
        {
            health = 200;
        }

        public override int Attack(Human target)
        {
            if (target.Health < 50)
            {
                target.Health = 0;
                return target.Health;
            } 
            else 
            {
                System.Console.WriteLine("Target's health is above 50");
                return target.Health;
            }
        }

        public int Meditate()
        {
            int backToLife = 200 - Health;
            Health += backToLife;
            return Health;
        }
        public override void getStats()
        {
            base.getStats();
        }

    }

}
