namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;

    [TestFixture]
    public class DatabaseTests
    {



        [Test]
        [TestCase(1, 10)]
        [TestCase(0, 15)]
        [TestCase(0, 0)]
        [TestCase(5, 1)]
        [TestCase(5, 16)]
        public void CTOR_ShouldAdd_Elements_SinceCountOfArrayIsLess16(int start, int count)
        {

            int[] elements = Enumerable.Range(start, count).ToArray();
            Database database = new Database(elements);
           


            Assert.AreEqual(count, database.Count);
        }


        [Test]
        [TestCase (1,10,3,13)]
        [TestCase(0, 15,1, 16)]
        [TestCase (0,0,16,16)]
        public void AddMethod_ShouldAdd_Elements_SinceCountOfArrayIsLess16(int start, int count, int toAdd, int result)
        {
            
            int[] elements = Enumerable.Range(start, count).ToArray();
            Database database = new Database(elements);
            for(int i = 0; i <toAdd; i++)
            {
                database.Add(1);
            }
           

            Assert.AreEqual(result, database.Count);
        }
        [Test]       
        [TestCase(0, 16)]
        
        public void AddMethod_ShoulThrowException_WhenCountOfArray_IsAboveOrEqualTo_16(int start, int count)
        {

            int[] elements = Enumerable.Range(start, count).ToArray();
            Database database = new Database(elements);



            Assert.Throws<InvalidOperationException>(() => { database.Add(1); }, "Array's capacity must be exactly 16 integers!");
        }
        [Test]
        public void RemoveMethod_ShoulThrowException_WhenCountOfArray_Is_0()
        {

            int[] elements = new int[0];
            Database database = new Database(elements);



            Assert.Throws<InvalidOperationException>(() => { database.Remove(); }, "The collection is empty!");
        }
        [Test]
        [TestCase(1, 10, 3, 7)]
        [TestCase(0, 16, 1, 15)]
        [TestCase(0, 16, 16, 0)]
        public void RemoveMethod_ShouldRemove_Elements_SinceCountOfArrayAbove_0(int start, int count, int toRemove, int result)
        {

            int[] elements = Enumerable.Range(start, count).ToArray();
            Database database = new Database(elements);
            for (int i = 0; i < toRemove; i++)
            {
                database.Remove();
            }


            Assert.AreEqual(result, database.Count);
        }
        [Test]
        [TestCase(1,16)]
        [TestCase(0, 16)]
        [TestCase(0,0)]
        [TestCase(0, 1)]
        [TestCase(3, 5)]
        [TestCase(5, 0)]
        public void FetchMethod_ShouldReturn_Elements_InArray(int start, int count)
        {

            int[] elements = Enumerable.Range(start, count).ToArray();
            Database database = new Database(elements);
            int[] fetchedDatabase = database.Fetch();
           


            Assert.AreEqual(elements, fetchedDatabase );
        }

    }
}
