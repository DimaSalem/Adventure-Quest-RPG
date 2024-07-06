using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Adventure_Quest_RPG
{
    public class Charachter : IBattleStates
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }

    }    
    public class Player: Charachter
    {   
        public Inventory InventoryList { get; set; }
        public Player()
        {
            Name = "Player";
            Health = 100;
            AttackPower = 100;
            Defense = 100;
            InventoryList = new Inventory();
        }

        public void UseItem(Item item)
        {
            if(InventoryList.Items.Contains(item))
            {
                int index= InventoryList.Items.IndexOf(item);
                switch(InventoryList.Items[index])
                {
                    case (Weapon):
                        this.AttackPower += 20;
                        break;
                    case (Potions):
                        this.Health += 20;
                        break;
                    case (Armor):
                        this.Defense += 20;
                        break;
                }
            }
        }
    }
    public abstract class Monster: Charachter
    {
        public Monster()
        {
            Name = "";
            Health = 100;
            AttackPower = 30;
            Defense = 30;
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
            Health = 100;
            AttackPower = 100;
            Defense = 100;
        }
    }

}
