using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Quest_RPG
{
    public class Inventory
    {
        public List<Item> Items;
        public Inventory()
        {
            Items = new List<Item>();
        }
        public void AddItem(Item item)
        {
            Items.Add(item);
        }
        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }
        public List <Item> GetItems()
        { 
            return Items;
        }
    }
}
