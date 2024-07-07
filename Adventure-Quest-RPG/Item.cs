using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Quest_RPG
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class Weapon : Item
    {
        public Weapon()
        {
            Name = "dagger ";
            Description = "A dagger is a short, double-edged knife for quick, precise strikes";
        }
    }
    public class Armor : Item
    {
        public Armor()
        {
            Name = "Armor";
            Description = "A breastplate is a sturdy, metal chest covering designed to protect the wearer from sharp impacts and direct attacks";
        }
    }
    public class Potions : Item
    {
        public Potions()
        {
            Name = "Potions";
            Description = "A healing potion is a magical liquid that swiftly restores the drinker's health and vitality";
        }

    }


}
