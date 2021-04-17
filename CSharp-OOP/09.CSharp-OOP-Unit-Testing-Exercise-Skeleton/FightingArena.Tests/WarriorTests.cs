using NUnit.Framework;
using FightingArena;
using System;

namespace Tests
{
    public class WarriorTests
    {


        [Test]
        [TestCase("", 50, 100)]
        [TestCase(" ", 50, 100)]
        [TestCase(null, 50, 100)]
        [TestCase("Warrior", 0, 100)]
        [TestCase("Warrior", -50, 100)]
        [TestCase("Warrior", 50, -100)]
        public void CTor_ThrowsException_WhenDataIsInvalid(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }
        [Test]
        [TestCase(30, 55)]
        [TestCase(15, 55)]
        [TestCase(55, 30)]
        [TestCase(55, 15)]
        public void Attack_ThrowsException_WhenHpIsLessThanMinimum(int attackerHp, int warriorHP)
        {
            var attacker = new Warrior("Attacker", 50, attackerHp);
            var warrior = new Warrior("Attacker", 10, warriorHP);
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }
        [Test]

        public void Attack_ThrowsException_WhenWarriorKillsTheAttacker()
        {
            var attacker = new Warrior("Attacker", 50, 100);
            var warrior = new Warrior("Attacker", attacker.HP + 2, 100);
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }
        [Test]

        public void Attack_DecreasesAttackerHealthPoint()
        {
            int initialAttackerHp = 100;
            var attacker = new Warrior("Attacker", 50, initialAttackerHp);
            var warrior = new Warrior("Attacker", 30, 100);
            attacker.Attack(warrior);

            Assert.That(attacker.HP, Is.EqualTo(initialAttackerHp - warrior.Damage));
        }
        [Test]

        public void Attack_SetEnemyHpToZero_WhenAttackerDamageIsGreaterThanEnemyHp()
        {

            var attacker = new Warrior("Attacker", 50, 100);
            var warrior = new Warrior("Attacker", 30, 40);
            attacker.Attack(warrior);

            Assert.That(warrior.HP, Is.EqualTo(0));
        }
        [Test]
        public void Attack_DecreasesEnemyHpByAtacckerDamage()
        {
            int warriorInitialHp = 100;
            Warrior attacker = new Warrior("Attacker", 50, 100);
            Warrior warrior = new Warrior("Attacker", 30, warriorInitialHp);
            attacker.Attack(warrior);

            Assert.That(warrior.HP, Is.EqualTo(warriorInitialHp - attacker.Damage));
        }
    }
}