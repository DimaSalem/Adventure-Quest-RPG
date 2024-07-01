using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Quest_RPG
{
    public class Charachter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }
    }
    public class PLayer: Charachter
    {   
        public int Level { get; set; }
        public PLayer()
        {
            Name = "Player";
            Health = 100;
            AttackPower = 100;
            Defense = 100;
            Level = 1;
        }
    }
    public abstract class Monster: Charachter
    {
        public Monster()
        {
            Name = "";
            Health = 100;
            AttackPower = 100;
            Defense = 100;
        }

        public abstract void AttackBehavior();
    }
    public class Zombie : Monster
    {
        public Zombie()
        {
            Name = "Zombie";
        }
        public override void AttackBehavior()
        {
            Console.Write("The Zombie shambles forward with a guttural moan, \nswinging its rotting arms to strike its prey");
        }
    }
    public class Skeleton : Monster
    {
        public Skeleton()
        {
            Name = "Skeleton";
        }
        public override void AttackBehavior()
        {
            Console.Write("The Skeleton draws its bow and fires arrows\n with deadly accuracy from a distance");
        }
    }
    public class Creeper : Monster
    {
        public Creeper()
        {
            Name = "Creeper";
        }
        public override void AttackBehavior()
        {
            Console.Write("The Creeper silently approaches and hisses menacingly\n before exploding in a deadly blast");
        }
    }

}
