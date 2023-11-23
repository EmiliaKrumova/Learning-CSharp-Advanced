namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Runtime.CompilerServices;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        [TestCase("Name", 5, 8)]
        [TestCase("*&^%%%%%%^^^^", 5, 0)]
        [TestCase("jaaaaaaaaaaaaaaa876at7tqygsuy%%&*&*(())", 100000000, 2000000000)]
        public void CtorShould_InitializeWarrior_Corect(string name, int damage, int hp)
        {
            Warrior warior = new Warrior(name, damage,hp);

            Assert.AreEqual(name, warior.Name);
            Assert.AreEqual(damage, warior.Damage);
            Assert.AreEqual(hp, warior.HP);
        }
        [TestCase("    ", 5, 0)]
        [TestCase("", 100000000, 2000000000)]
        [TestCase(null, 5, 0)]
        public void CtorShould_ThrowException_WhenName_IsNullOrEmpty(string name, int damage, int hp)
        {

            ArgumentException ex =  Assert.Throws<ArgumentException>(() =>
            {
                Warrior warior = new Warrior(name, damage, hp);
            });
            Assert.AreEqual("Name should not be empty or whitespace!", ex.Message);
           
        }
        [TestCase("warrior", 0, 0)]
        [TestCase("strong", -100000000, 2000000000)]
        [TestCase("stringstringstrinG&^78", -1, 5666)]
        public void CtorShould_ThrowException_WhenDamageIs_0_Or_Negative(string name, int damage, int hp)
        {
            //throw new ArgumentException("Damage value should be positive!");

            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                Warrior warior = new Warrior(name, damage, hp);
            });
            Assert.AreEqual("Damage value should be positive!", ex.Message);

        }
        [TestCase("warrior", 1, -1)]
       
        [TestCase("stringstringstrinG&^78", 200000000, -5666)]
        public void CtorShould_ThrowException_WhenHPIs_Negative(string name, int damage, int hp)
        {
            //throw new ArgumentException("HP should not be negative!");

            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                Warrior warior = new Warrior(name, damage, hp);
            });
            Assert.AreEqual("HP should not be negative!", ex.Message);

        }
        [TestCase("warrior", 1, 29)]
        [TestCase("stringstringstrinG&^78", 200000000, 0)]
        [TestCase("warrior", 40, 1)]
        public void AttackMethod_ShouldThrowException_WhenWarriorHP_IsLessThan30(string name, int damage, int hp)
        {
            //throw new InvalidOperationException("Your HP is too low in order to attack other warriors!");
            Warrior warior = new Warrior(name, damage, hp);
            Warrior enemy = new Warrior("badGuy", 35, 55);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                warior.Attack(enemy); 
            });
            Assert.AreEqual("Your HP is too low in order to attack other warriors!", ex.Message);

        }
        [TestCase("warrior", 1, 29)]
        [TestCase("stringstringstrinG&^78", 200000000, 0)]
        [TestCase("warrior", 40, 1)]
        public void AttackMethod_ShouldThrowException_WhenEnemyHP_IsLessThan30(string enemyName, int enemyDamage, int enemyHp)
        {
            const int minHPForEnemy = 30;
            //throw new InvalidOperationException($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!");
            Warrior enemy = new Warrior(enemyName, enemyDamage, enemyHp);
            Warrior warrior = new Warrior("Shwarzeneger", 35, 55);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(enemy);
            });
            Assert.AreEqual($"Enemy HP must be greater than {minHPForEnemy} in order to attack him!", ex.Message);

        }
        [TestCase("badGuy", 56, 31)]
        [TestCase("stringstringstrinG&^78", 200000000, 76)]
        [TestCase("677yhsggw55", 455, 11111111)]
        public void AttackMethod_ShouldThrowException_WhenEnemyDamage_IsMoreThan_WarriorHP(string enemyName, int enemyDamage, int enemyHp)
        {

            //throw new InvalidOperationException($"You are trying to attack too strong enemy");
            Warrior enemy = new Warrior(enemyName, enemyDamage, enemyHp);
            Warrior warrior = new Warrior("Shwarzeneger", 35, 55);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(enemy);
            });
            Assert.AreEqual($"You are trying to attack too strong enemy", ex.Message);

        }
        [TestCase(31,31)]
        [TestCase(101, 71)]
        [TestCase(987631, 111)]
        public void AttackMethod_ShouldDecreaseWarriorHP_WithValueOf_EnemyDamage(int warriorHP,int enemyDamage)
        {
            Warrior warrior = new Warrior("GoodBoy", 35, warriorHP);
            Warrior enemy = new Warrior("TheDevil", enemyDamage, 55);
            warrior.Attack(enemy);
            int expectedHPForWarrior = warriorHP - enemyDamage;
            Assert.AreEqual(expectedHPForWarrior, warrior.HP);

        }
        [TestCase(32, 31)]
        [TestCase(101, 100)]
        [TestCase(987631, 111)]
        public void AttackMethod_ShouldDecreaseEnemyHpTo_0_When_WariorDamageIs_BiggerThanEnemyHP(int warriorDamage, int enemyHP)
        {
            Warrior warrior = new Warrior("GoodBoy", warriorDamage, 55);
            Warrior enemy = new Warrior("TheDevil", 55, enemyHP);
            warrior.Attack(enemy);
            int expectedHPforEnemy = 0;
            Assert.AreEqual(expectedHPforEnemy, enemy.HP);

        }
        [TestCase(31, 31)]
        [TestCase(56, 100)]
        [TestCase(98, 7631999)]
        public void AttackMethod_ShouldDecreaseEnemyHp_WithValueOfWarriorDamage_When_WariorDamageIs_EqualOrLess_ThanEnemyHP(int warriorDamage, int enemyHP)
        {
            Warrior warrior = new Warrior("GoodBoy", warriorDamage, 55);
            Warrior enemy = new Warrior("TheDevil", 55, enemyHP);
            warrior.Attack(enemy);
            int expectedHPforEnemy = enemyHP-warriorDamage;
            Assert.AreEqual(expectedHPforEnemy, enemy.HP);

        }

    }
}