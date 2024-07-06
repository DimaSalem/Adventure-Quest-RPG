using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Quest_RPG
{
    public class BattleSystem
    {
        static Random random = new Random();
        public Player player {  get; set; }
        public Monster monster { get; set; }
        public bool playerLost {  get; set; }
        static public Monster selectMonsterTypeRandomly()
        {
            int monsterType = random.Next(1, 4);
            switch (monsterType)
            {
                case 1:
                    return new Zombie();
                case 2:
                    return new Creeper();
                case 3:
                    return new Skeleton();
                default:
                    return new Skeleton();
            }
        }    
        public BattleSystem()
        {
            player = new Player();
            monster = selectMonsterTypeRandomly();
            playerLost = false;
        }
        public void Attack(Charachter attaker, Charachter target)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{attaker.Name} attacks with Attack Power={attaker.AttackPower}");
            Console.WriteLine($"{target.Name} defends with Defense={target.Defense} and Health={target.Health}");

            int damage = attaker.AttackPower - target.Defense;
            if(damage < 0)
                damage = 0;
            target.Health -= damage;
            if (target.Health < 0)
                target.Health = 0;

            //attaker.AttackPower -= 10;
            //target.Defense -= 10;
            //if (attaker.AttackPower < 0)
            //    attaker.AttackPower = 0;
            //if (target.Defense < 0)
            //    target.Health = 0;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Attack Results: {attaker.Name} causes damage={damage} so {target.Name}" +
                $" health drops down to {target.Health}");
            Console.ResetColor();
        }
        //public bool IsItemDropped()
        //{
        //    int isItemDroppedRandom = random.Next(1, 4);
        //    return (isItemDroppedRandom == 2 ? true : false);
        //}
        public void AddRandomItem()
        {
            int itemType= random.Next(1, 4);
            switch (itemType)
            {
                case 1:
                    player.InventoryList.AddItem(new Weapon());
                    break;
                case 2:
                    player.InventoryList.AddItem(new Potions());
                    break;
                default:
                    player.InventoryList.AddItem(new Armor());
                    break;
            }
        }
        public void StartBattle()
        {
            if(player.InventoryList.Items.Count > 0)
            {
                for(int i = 0;i< player.InventoryList.Items.Count;i++)
                {
                    player.UseItem(player.InventoryList.Items[i]);
                    Console.WriteLine($"player is now using {player.InventoryList.Items[i].Name}");
                }
            }
            while (player.Health > 0 && monster.Health > 0)
            {
                //Console.ReadKey();

                Console.WriteLine("\nPlayer Turn");
                //test
                /*foreach (var item in player.InventoryList.GetItems())
                {
                    Console.WriteLine(item);
                    player.UseItem(item);
                }*/
                Attack(player, monster);
                if (monster.Health == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\n**Battle Over**");
                    Console.WriteLine("**Congrats You Win**");
                    Console.ResetColor();
                    if (monster.Health == 0)
                    {
                        AddRandomItem();
                        Console.WriteLine($"{monster.Name} dropped a" +
                            $" {player.InventoryList.Items[player.InventoryList.Items.Count - 1].Name}," +
                            $" its added to your inventory");
                    }
                    break;
                }

                //Console.ReadKey();

                Console.WriteLine("\nMonster Turn");
                Attack(monster, player);
                if (player.Health == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\n**Battle Over**");
                    Console.WriteLine("**You Lost**");
                    Console.ResetColor();
                    playerLost = true;
                    break;
                }
            }
        }

    }
}
