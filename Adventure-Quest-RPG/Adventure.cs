﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Quest_RPG
{
    public class Adventure
    {
        public List<string> locations { get; set; }
        public string currentLocation { get; set; }
        public List<Monster> monsters { get; set; }
        public int numbersOfBossesEncountered {  get; set; }
        public string action { get; set; }
        public Adventure()
        {
            locations = new List<string>();
            AddLocations(locations);
            currentLocation = SelectRandomLocation(locations);
            monsters = new List<Monster>();
            AddMonsters(monsters);
            numbersOfBossesEncountered = 0;
            action = "No action yet";
        }
        public void AddLocations(List<string> locations)
        {
            locations.Add("Forest");
            locations.Add("Cave");
            locations.Add("Town");
        }
        public void AddMonsters(List<Monster> monsters)
        {
            for (int i = 0; i < 3; i++)
            {
                Monster monster = BattleSystem.selectMonsterTypeRandomly();
                monsters.Add(monster);
            }
            Dragon dragon = new Dragon();
            monsters.Add(dragon);
        }
        public string SelectRandomLocation(List<string> locations)
        {
            Random random = new Random();
            int number = random.Next(1, 4);
            switch (number)
            {
                case 1:
                    return locations[0];
                case 2:
                    return locations[1];
                default:
                    return locations[2];
            }
        }
        public void AdventureManager()
        {
            Console.WriteLine("Welcome to RPG Adventure, enter start to begin the game!");
            string userStart = Console.ReadLine();
            bool endGame = false;
            while (userStart.ToLower() != "start")
            {
                Console.WriteLine("You should type start, then press enter to begin the game!");
                userStart = Console.ReadLine();
            }
            while (endGame == false)
            {       
                Console.WriteLine($"Your current location is {currentLocation}, and there are 3 monsters in front" +
                    $" of you, choose an action:\n Attack The monsters (enter A) \n Change your location (enter L) \n End the game (enter E)");
                string userAction = Console.ReadLine();
                while (userAction.ToLower() != "a" && userAction.ToLower() != "l" && userAction.ToLower() != "e")
                {
                    Console.WriteLine("Please enter A or L or E");
                    userAction = Console.ReadLine();
                }
                if (userAction.ToLower() == "e")
                {
                    endGame = true;
                    continue;
                }
                else if (userAction.ToLower() == "l")
                {
                    ChangeLocation();
                    continue;
                }
                else
                {
                    Attack();
                    monsters.Clear();
                    AddMonsters(monsters);
                }
            }
        }
        public void ChangeLocation()
        {
            string newLocation = SelectRandomLocation(locations);
            while (newLocation == currentLocation)
            {
                newLocation = SelectRandomLocation(locations);
            }
            currentLocation = newLocation;
        }
        public void Attack()
        {
            Console.WriteLine("You will now battle against 3 monsters and a final boss,\n " +
                        "each time you win against a monster you will gain full health, defeat them to win the game");
            BattleSystem battle = new BattleSystem();
            for (int i = 0; i < monsters.Count; i++)
            {
                battle.monster = monsters[i];
                if (monsters[i].Name == "Dragon")
                {
                    numbersOfBossesEncountered++;
                }
                battle.StartBattle();
                if (battle.playerLost == true)
                {
                    break;
                }
            }
            
        }
    }
}