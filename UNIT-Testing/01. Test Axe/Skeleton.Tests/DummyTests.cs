using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        

        [Test]
        public void WhenDummyTakesAttack_HealthShouldDecrease_WithAttackedPoints()
        {
            // Dummy loses health if attacked

            Dummy dummy = new Dummy(20, 20);
            dummy.TakeAttack(10);

            Assert.AreEqual(10, dummy.Health);
            
            
        }
        //Dead Dummy throws an exception if attacked
        [Test]
        public void WhenAttacked_Dummy_IsDead_ShouldThrow_Exeption()
        {
            Dummy dummy1 = new Dummy(0, 20);
            Assert.Throws<InvalidOperationException>(() => { dummy1.TakeAttack(0); }, "Dummy is dead.");
        }

        //Dead Dummy can give XP
        [Test]
        public void WhenDummy_IsDead_CanGive_XP()
        {
            Dummy dummy = new Dummy(0, 20);

            Assert.AreEqual(20, dummy.GiveExperience());
        }
        //Alive Dummy can't give XP
        [Test]
        public void When_Dummy_IsNOTDead_ShouldThrow_Exeption()
        {
            Dummy dummy1 = new Dummy(20, 20);
            Assert.Throws<InvalidOperationException>(() => { dummy1.GiveExperience(); }, "Target is not dead.");
        }

    }
}