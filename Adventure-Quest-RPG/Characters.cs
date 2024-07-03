using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Adventure_Quest_RPG
{
    public interface IBattleStates
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }
    }
    public class Charachter : IBattleStates
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
    }
    public class Zombie : Monster
    {
        public Zombie()
        {
            Name = "Zombie";
        }   
    }
    public class Skeleton : Monster
    {
        public Skeleton()
        {
            Name = "Skeleton";
        }
    }
    public class Creeper : Monster
    {
        public Creeper()
        {
            Name = "Creeper";
        }
    }
    public class Dragon: Monster
    {
        public Dragon()
        {
            Name = "Dragon";
            Health = 500;
            AttackPower = 500;
            Defense = 500;
        }
    }

}
