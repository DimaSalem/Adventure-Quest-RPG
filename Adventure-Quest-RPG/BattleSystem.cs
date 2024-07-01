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
        Monster selectMonsterTypeRandomly()
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

        private void displayCharachtersInfo()
        {
            Console.WriteLine("Game Start");
            Console.WriteLine($"Your level is LEVEL{player.Level}");
            Console.Write("Your opponent ");
            monster.AttackBehavior();
            Console.WriteLine("\n----------------------------------------------------------------------");
        }
        private void playerLevelUp()
        {
            player.Level++;
            player.AttackPower = 100 + player.Level * 10;
            player.Defense = 100 + player.Level * 10;
            player.Health = 100 + player.Level * 10;
        }
        private void resetMonsterAttributes()
        {
            monster = selectMonsterTypeRandomly();
        }
        private void resetPlayerAttributes()
        {
            player.Defense = 100;
            player.Health = 100;   
            player.AttackPower = 100;
        }

        public void playBattleRound()
        {
            int rounds = 0;
            while (player.Health > 0 || monster.Health > 0)
            {
                //Console.ReadKey();

                Console.WriteLine("\nPlayer Turn");
                Attack(player, monster);
                rounds++;
                if (monster.Health == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\n**Game Over**");
                    Console.WriteLine("**Congrats You Win**");
                    Console.WriteLine($"**Game Ends in {rounds} rounds**");
                    Console.ResetColor();
                    break;
                }

                //Console.ReadKey();

                Console.WriteLine("\nMonster Turn");
                Attack(monster, player);
                rounds++;
                if (player.Health == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\n**Game Over**");
                    Console.WriteLine("**You Lost**");
                    Console.ResetColor();
                    break;
                }
            }
        }
        public void StartBattle()
        {
            string answer = "";
            do
            {
                if (answer.ToUpper() == "Y")
                {
                    if (monster.Health == 0)
                        playerLevelUp();
                    else if (player.Health == 0)
                        resetPlayerAttributes();

                    resetMonsterAttributes();
                }
                Console.Clear();
                displayCharachtersInfo();
                playBattleRound();
                Console.WriteLine("Do you want to play another round? Y/N");
                answer = Console.ReadLine();

            } while (answer.ToUpper() == "Y");
            
        }

    }
}
