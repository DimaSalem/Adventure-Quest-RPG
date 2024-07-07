using System.Runtime.CompilerServices;
using Xunit;
using Adventure_Quest_RPG;

namespace AdventureQuestRPGTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestHealthReducing_PlayerAttacksCase()
        {
            BattleSystem battle = new BattleSystem();

            int expectedDamage = battle.player.AttackPower / 2 - battle.monster.Defense / 4;
            int expectedHealth = battle.monster.Health - expectedDamage;

            battle.Attack(battle.player, battle.monster);

            int actualHealth=battle.monster.Health;

            Assert.Equal(expectedHealth, actualHealth);
        }

        [Fact]
        public void TestHealthReducing_MonsterAttacksCase()
        {
            BattleSystem battle = new BattleSystem();

            int expectedDamage = battle.monster.AttackPower / 2 - battle.player.Defense / 4;
            int expectedHealth = battle.player.Health - expectedDamage;

            battle.Attack(battle.monster, battle.player);

            int actualHealth = battle.player.Health;

            Assert.Equal(expectedHealth, actualHealth);
        }

         [Fact]
        public void TestHealthAfterBattle()
        {
            BattleSystem battle = new BattleSystem();
            battle.StartBattle();

            //the winner is the player 
            Assert.True(battle.player.Health>0);
        }
        [Fact]
        public void EncounteringBossTest()
        {
            Adventure adventure = new Adventure();
            adventure.Attack();
            Assert.Equal(1, adventure.numbersOfBossesEncountered);
        }
        [Fact]
        public void ChangeLocationTest()
        {
            Adventure adventure = new Adventure();
            string oldLocation = adventure.currentLocation;
            adventure.ChangeLocation();
            Assert.True(adventure.currentLocation != oldLocation);
        }
    }
}