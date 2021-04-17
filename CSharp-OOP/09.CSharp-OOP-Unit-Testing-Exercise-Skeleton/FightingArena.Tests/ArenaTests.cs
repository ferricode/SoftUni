using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void Ctor_InitializeWarriors()
        {
            Assert.That(this.arena.Warriors, Is.Not.Null);
        }
        [Test]
        public void Count_IsZero_WhenArenaIsEmpty()
        {
            Assert.That(this.arena.Count, Is.EqualTo(0));
        }
        [Test]
        public void Enroll_ThrowException_WhenWarriorAlreadyExist()
        {
            string name = "Warrior";
            this.arena.Enroll(new Warrior(name, 50, 50));

            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(new Warrior(name, 60, 70)));
        }
        [Test]
        public void Enroll_IncreasesCountWhenAddsWarrior()
        {

            this.arena.Enroll(new Warrior("Warrior", 50, 50));
            Assert.That(this.arena.Count, Is.EqualTo(1));
        }
        [Test]
        public void Enroll_AddsWarriorToWarriors()
        {
            string name = "Warrior";

            this.arena.Enroll(new Warrior(name, 50, 50));

            Assert.That(arena.Warriors.Any(w => w.Name == name), Is.True);
        }
        [Test]
        public void Fight_ThrowsException_WhenAttackerDoesNotExist()
        {
            string attacker = "Attacker";

            this.arena.Enroll(new Warrior(attacker, 50, 50));

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker, "Defender"));
        }
        [Test]
        public void Fight_ThrowsException_WhenDefenderDoesNotExist()
        {
            string defender = "Deffender";

            this.arena.Enroll(new Warrior(defender, 50, 50));

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Attacker", defender));
        }
        [Test]
        public void Fight_ThrowsException_WhenDefenderAndAttackerDoesNotExists()
        {

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Attacker", "Deffender"));
        }
        [Test]
        public void Fight_BothWarriorsLoseHpInFight()
        {
            var initialHp = 100;
            var attacker = new Warrior("Attacker", 50, initialHp);
            var deffender = new Warrior("Deffender", 50, initialHp);

            this.arena.Enroll(attacker);
            this.arena.Enroll(deffender);
            this.arena.Fight(attacker.Name, deffender.Name);

            Assert.That(attacker.HP,Is.EqualTo(initialHp-deffender.Damage));
            Assert.That(deffender.HP,Is.EqualTo(initialHp-attacker.Damage));
        }

    }
}
