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

        public bool UseItem(Item item)
        {
            if(InventoryList.Items.Contains(item))
            {
                int index= InventoryList.Items.IndexOf(item);
                switch(InventoryList.Items[index])
                {
                    case (Weapon):
                        this.AttackPower += 20;
                        AttackPower = (AttackPower > 100 ? 100: AttackPower);
                        break;
                    case (Potions):
                        this.Defense += 20;
                        Defense = (Defense > 100 ? 100 : Defense);
                        break;
                    case (Armor):
                        this.Health += 20;
                        Health = (Health > 100 ? 100 : Health);
                        break;
                }
                return true;
            }
            else 
                return false;
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
