using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Quest_RPG
{
    public class BattleSystem
    {
        public PLayer player {  get; set; }
        public Monster monster { get; set; }
        public Monster selectMonsterTypeRandomly()
        {
            Random random = new Random();
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
            player = new PLayer();
            monster = selectMonsterTypeRandomly();
            //monster = new Dragon();
        }
        public void Attack(Charachter attaker, Charachter target)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{attaker.Name} attacks with Attack Power={attaker.AttackPower}");
            Console.WriteLine($"{target.Name} defends with Defense={target.Defense} and Health={target.Health}");

            int damage = attaker.AttackPower/2 - target.Defense/4;
            if(damage < 0)
                damage = 0;
            target.Health -= damage;
            if (target.Health < 0)
                target.Health = 0;

            attaker.AttackPower -= 10;
            target.Defense -= 10;
            if (attaker.AttackPower < 0)
                attaker.AttackPower = 0;
            if (target.Defense < 0)
                target.Health = 0;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Attack Results: {attaker.Name} causes damage={damage} so {target.Name}" +
                $" health drops down to {target.Health}");
            Console.ResetColor();
        }
        public void StartBattle()
        {
            while (player.Health > 0 || monster.Health > 0)
            {
                //Console.ReadKey();

                Console.WriteLine("\nPlayer Turn");
                Attack(player, monster);
                if (monster.Health == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\n**Battle Over**");
                    Console.WriteLine("**Congrats You Win**");
                    Console.ResetColor();
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
                    break;
                }
            }
        }

    }
}
