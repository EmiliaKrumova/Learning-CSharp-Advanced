namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void CtorShouldCreateCollectionCorectly()
        {   
            Arena arena = new Arena();

            Assert.IsNotNull(arena.Warriors);

        }
        [Test]
        public void CountMethodShouldCountListOfWarriors()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("valid", 50, 50);

            arena.Enroll(warrior);
            int expectedCount = 1;
            Assert.AreEqual(expectedCount, arena.Count);

        }
        [Test]
        public void EnrollMethodShouldAddWarrior()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("valid", 39, 40);

            arena.Enroll(warrior);
            int expectedCount = 1;
            Assert.AreEqual(expectedCount, arena.Warriors.Count);

        }
        [Test]
        public void EnrollMethodShouldThrowException_WhenAdd_SameWarrior()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("valid", 39, 40);

            //throw new InvalidOperationException("Warrior is already enrolled for the fights!");

            arena.Enroll(warrior);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => { arena.Enroll(warrior); });
            Assert.AreEqual("Warrior is already enrolled for the fights!", exception.Message);
        }
        [Test]
        public void FightMethodShouldThrowException_WhenDefenderIsNull()
        {
            
            Arena arena = new Arena();
            Warrior deffender = null;
            Warrior attacker = new Warrior("valid", 39, 40);

            //throw new InvalidOperationException($"There is no fighter with name {missingName} enrolled for the fights!");

            
            string deffenderName = "something";
           

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => { arena.Fight(attacker.Name,deffenderName); });
            Assert.AreEqual($"There is no fighter with name {deffenderName} enrolled for the fights!", exception.Message);
        }
        [Test]
        [TestCase("attacker", "defender")]
        public void FightMethodShouldThrowException_WhenAttackerIsNull(string atName, string defName)
        {
            Arena arena = new Arena();
            Warrior attacker = null;
            Warrior deffender = new Warrior(defName, 39, 40);           
            arena.Enroll(deffender);      


            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => { arena.Fight(atName, defName); });
            Assert.AreEqual($"There is no fighter with name {atName} enrolled for the fights!", exception.Message);
        }
        [Test]
        [TestCase("attacker", "defender")]
        public void FightMethodShouldInvokeAttackMethodFromClassWariorWhenAttackerAndDeffenderAreValid(string atName, string defName)
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior(atName, 50, 40);
            Warrior deffender = new Warrior(defName, 40, 50);
            arena.Enroll(deffender);
            arena.Enroll(attacker);
            arena.Fight(atName, defName);


            Assert.AreEqual(0, attacker.HP);
            Assert.AreEqual(0, deffender.HP);
        }
    }
}
