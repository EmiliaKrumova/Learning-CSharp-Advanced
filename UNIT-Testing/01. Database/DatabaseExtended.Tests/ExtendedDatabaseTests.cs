namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;
        //[SetUp]
        //public void SetUp()
        //{

        //    Person[] people = new Person[10];

        //    for (int i = 0; i < 16; i++)
        //    {
        //        Person person = new Person(i, $"gosho+{i}");
        //        people[i] = person;

        //    }
        //    database = new Database(people);

        //}

        [Test]
        [TestCase(10)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(16)]
        [TestCase(8)]

        public void CTOR_ShouldAdd_Elements_SinceCountOfArrayIsLess16(int count)
        {


            Person[] people = new Person[count];

            for (int i = 0; i < count; i++)
            {
                Person person = new Person(i, $"Gosho+{i}");
                people[i] = person;

            }
            database = new Database(people);



            Assert.AreEqual(count, database.Count);
        }


        [Test]
        [TestCase(0,"Pesho")]
        [TestCase(-89, "Ivan")]
        [TestCase(299_999_999_999, "Onia")]
        [TestCase(90000, "MNOOOOOOOOGOOOOOO Dylyg STRIIIIIIIIIIIIIIIIIIIIIIIIIIIING")]

        
        public void WhenCreateNewPerson_ShouldCreateCorrectly_ObjectPerson(long id,string name)
        {
            Person person = new Person(id, name);

            Assert.AreEqual(id, person.Id);
            Assert.AreEqual(name, person.UserName);
        }
        [Test]
        public void Database_Ctor_ShouldCreate_NotNULL_DatabaseObject()
        {
            Person[] people = new Person[16];

            for (int i = 0; i < 16; i++)
            {
                Person person = new Person(i, $"gosho+{i}");
                people[i] = person;

            }
            database = new Database(people);
            Assert.IsNotNull(database);
        }
        [Test]
        public void Database_Count_ShouldReturn_CorrectCount_DatabaseObject()
        {
            Person[] people = new Person[10];

            for (int i = 0; i < 10; i++)
            {
                Person person = new Person(i, $"gosho+{i}");
                people[i] = person;
                

            }
            database = new Database(people);
            Assert.AreEqual(10,database.Count);
        }
        [Test]
        public void AddMethod_ShouldAdd_PeopleToDatabase_UntilDatabaseCountIsLessThan_16()
        {
            Person[] people = new Person[10];
            database = new Database();

            for (int i = 0; i < 10; i++)
            {
                Person person = new Person(i, $"gosho+{i}");
               
                database.Add(person);

            }
          


            Assert.AreEqual(10,database.Count);
  
 
        }
        [Test]
        public void AddMethod_ShouldThrowException_When_DatabaseCount_IsAbove_16()
        {
            Person[] people = new Person[16];
            Person person = new Person(0,"");

            for (int i = 0; i < 16; i++)
            {
                 person = new Person(i, $"gosho+{i}");
                people[i] = person;

            }
            database = new Database(people);
            



           Assert.Throws<InvalidOperationException>(() => {  database.Add(person); }, "Array's capacity must be exactly 16 integers!");


        }
    }
}