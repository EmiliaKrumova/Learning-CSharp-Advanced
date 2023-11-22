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
        [TestCase(17)]
        [TestCase(56)]
        public void CTOR_ShouldThrowException_WhenCountOfArrayIsAbove16(int count)
        {


            Person[] people = new Person[count];

            for (int i = 0; i < count; i++)
            {
                Person person = new Person(i, $"Gosho+{i}");
                people[i] = person;

            }




            Assert.Throws<ArgumentException>(() => { database = new Database(people); }, "Provided data length should be in range [0..16]!");
        }


        [Test]
        [TestCase(0,"Pesho")]
        [TestCase(89, "Ivan")]
        [TestCase(299_999_999_999, "Onia")]
        [TestCase(90000, "MNOOOOOOOOGOOOOOO Dylyg STRIIIIIIIIIIIIIIIIIIIIIIIIIIIING")]

        
        public void WhenCreateNewPerson_ShouldCreateCorrectly_ObjectPerson(long id,string name)
        {
            Person person = new Person(id, name);

            Assert.AreEqual(id, person.Id);
            Assert.AreEqual(name, person.UserName);
        }
        [Test]
        public void DatabaseAddMethodShouldIncreaseCount()
        {
            Person[] people =
       {
            new Person(1, "Pesho"),
            new Person(2, "Gosho"),
            new Person(3, "Ivan_Ivan"),
            new Person(4, "Pesho_ivanov"),
            new Person(5, "Gosho_Naskov"),
            new Person(6, "Pesh-Peshov"),
            new Person(7, "Ivan_Kaloqnov"),
            new Person(8, "Ivan_Draganchov"),
            new Person(9, "Asen"),
            new Person(10, "Jivko"),
            new Person(11, "Toshko")
        };
            database = new Database(people);
            Person person = new Person(12, "Paul");

            database.Add(person);

            int expectedResult = 12;
            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
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
            Person person;

            for (int i = 0; i < 16; i++)
            {
                 person = new Person(i, $"gosho+{i}");
                people[i] = person;

            }
            database = new Database(people);
            person = new Person(17, "Nekoi");

            Assert.Throws<InvalidOperationException>(() => { database.Add(person); }, "Array's capacity must be exactly 16 integers!");

        }
        [Test]
        
        [TestCase(1)]
        [TestCase(7)]
        [TestCase(11)]
        public void AddMethod_ShouldThrowException_When_DatabaseContains_ThisUserID(int count)
        {
            Person[] people =
        {
            new Person(1, "Pesho"),
            new Person(2, "Gosho"),
            new Person(3, "Ivan_Ivan"),
            new Person(4, "Pesho_ivanov"),
            new Person(5, "Gosho_Naskov"),
            new Person(6, "Pesh-Peshov"),
            new Person(7, "Ivan_Kaloqnov"),
            new Person(8, "Ivan_Draganchov"),
            new Person(9, "Asen"),
            new Person(10, "Jivko"),
            new Person(11, "Toshko")
        };

            database = new Database(people);

           Person personToAdd = new Person(count, "NoOne");


            Assert.Throws<InvalidOperationException>(() => { database.Add(personToAdd); }, "There is already user with this Id!");


        }
        [Test]
        public void AddMethod_ShouldThrowException_When_DatabaseContains_ThisUserName()
        {
            Person[] people =
        {
            new Person(1, "Pesho"),
            new Person(2, "Gosho"),
            new Person(3, "Ivan_Ivan"),
            new Person(4, "Pesho_ivanov"),
            new Person(5, "Gosho_Naskov"),
            new Person(6, "Pesh-Peshov"),
            new Person(7, "Ivan_Kaloqnov"),
            new Person(8, "Ivan_Draganchov"),
            new Person(9, "Asen"),
            new Person(10, "Jivko"),
            new Person(11, "Toshko")
        };

            database = new Database(people);

            Person personToAdd = new Person(12, "Jivko");


            Assert.Throws<InvalidOperationException>(() => { database.Add(personToAdd); }, "There is already user with this username!");


        }
        [Test]
        public void RemoveMethod_ShoulThrowException_WhenCountOfArray_Is_0()
        {

            Person[] people = new Person[0];
            Database database = new Database(people);



            Assert.Throws<InvalidOperationException>(() => { database.Remove(); });
        }
        [Test]
        [TestCase(16,5)]
        [TestCase(16,16)]
        [TestCase(1,0)]
        public void RemoveMethod_ShouldRemove_Elements_SinceCountOfArrayAbove_0(int count,int toRemove)
        {
            int result = count - toRemove;

            Person[] people = new Person[count];
            for (int i = 0; i < count; i++)
            {
               Person person = new Person(i, $"gosho+{i}");
                people[i] = person;

            }
            Database database = new Database(people);
            for (int i = 0; i < toRemove; i++)
            {
                database.Remove();
               
            }


            Assert.AreEqual(result, database.Count);
        }
        [Test]
        public void RemoveMethod_Decrease_CountOf_Database()
        {
            Person[] people =
        {
            new Person(1, "Pesho"),
            new Person(2, "Gosho"),
            new Person(3, "Ivan_Ivan"),
            new Person(4, "Pesho_ivanov"),
            new Person(5, "Gosho_Naskov"),
            new Person(6, "Pesh-Peshov"),
            new Person(7, "Ivan_Kaloqnov"),
            new Person(8, "Ivan_Draganchov"),
            new Person(9, "Asen"),
            new Person(10, "Jivko"),
            new Person(11, "Toshko")
        };

            database = new Database(people);

            database.Remove();


           Assert.AreEqual(10,database.Count);


        }
        [Test]
        [TestCase("Asen")]
        [TestCase("Gosho")]
        public void FindByUsername_Method_ShouldFindUsers_ByUsername(string username)
        {
            Person[] people =
       {
            new Person(1, "Pesho"),
            new Person(2, "Gosho"),
            new Person(3, "Ivan_Ivan"),
            new Person(4, "Pesho_ivanov"),
            new Person(5, "Gosho_Naskov"),
            new Person(6, "Pesh-Peshov"),
            new Person(7, "Ivan_Kaloqnov"),
            new Person(8, "Ivan_Draganchov"),
            new Person(9, "Asen"),
            new Person(10, "Jivko"),
            new Person(11, "Toshko")
        };

            database = new Database(people);
            string expectedUsername = username;
            string actualResultForUsername = database.FindByUsername(username).UserName;
            Assert.AreEqual(expectedUsername, actualResultForUsername);

        }
        [Test]
       
        
        public void FindByUsername_Method_ShouldBe_CaseSensitive()
        {
            Person[] people =
       {
            new Person(1, "Pesho"),
            new Person(2, "Gosho"),
            new Person(3, "Ivan_Ivan"),
            new Person(4, "Pesho_ivanov"),
            new Person(5, "Gosho_Naskov"),
            new Person(6, "Pesh-Peshov"),
            new Person(7, "Ivan_Kaloqnov"),
            new Person(8, "Ivan_Draganchov"),
            new Person(9, "Asen"),
            new Person(10, "Jivko"),
            new Person(11, "Toshko")
        };

            database = new Database(people);
            string expectedUsername = "GOSHO";
            string actualResultForUsername = database.FindByUsername("Gosho").UserName;
            Assert.AreNotEqual(expectedUsername, actualResultForUsername);

        }
        [Test]
        public void FindByUsername_Method_ShouldThrowExeption_WhenUsernameIs_Empty()
        {
            Person[] people =
       {
            new Person(1, "Pesho"),
            new Person(2, "Gosho"),
            new Person(3, "Ivan_Ivan"),
            new Person(4, "Pesho_ivanov"),
            new Person(5, "Gosho_Naskov"),
            new Person(6, "Pesh-Peshov"),
            new Person(7, "Ivan_Kaloqnov"),
            new Person(8, "Ivan_Draganchov"),
            new Person(9, "Asen"),
            new Person(10, "Jivko"),
            new Person(11, "Toshko")
        };

            database = new Database(people);
            string expectedUsername = "";
           
            Assert.Throws<ArgumentNullException>(() => { database.FindByUsername(expectedUsername); },"Username parameter is null!");

            

        }
        [Test]
        public void FindByUsername_Method_ShouldThrowExeption_WhenUsernameIs_Null()
        {
            Person[] people =
       {
            new Person(1, "Pesho"),
            new Person(2, "Gosho"),
            new Person(3, "Ivan_Ivan"),
            new Person(4, "Pesho_ivanov"),
            new Person(5, "Gosho_Naskov"),
            new Person(6, "Pesh-Peshov"),
            new Person(7, "Ivan_Kaloqnov"),
            new Person(8, "Ivan_Draganchov"),
            new Person(9, "Asen"),
            new Person(10, "Jivko"),
            new Person(11, "Toshko")
        };

            database = new Database(people);
            string expectedUsername = null;

            Assert.Throws<ArgumentNullException>(() => { database.FindByUsername(expectedUsername); }, "Username parameter is null!");



        }
        [Test]
        [TestCase("Emilia")]
        [TestCase("Ime")]
        public void FindByUsername_Method_ShouldThrowExeption_WhenUsernameIs_NotFound(string expectedUserName)
        {
            Person[] people =
       {
            new Person(1, "Pesho"),
            new Person(2, "Gosho"),
            new Person(3, "Ivan_Ivan"),
            new Person(4, "Pesho_ivanov"),
            new Person(5, "Gosho_Naskov"),
            new Person(6, "Pesh-Peshov"),
            new Person(7, "Ivan_Kaloqnov"),
            new Person(8, "Ivan_Draganchov"),
            new Person(9, "Asen"),
            new Person(10, "Jivko"),
            new Person(11, "Toshko")
        };

            database = new Database(people);
            

            Assert.Throws<InvalidOperationException>(() => { database.FindByUsername(expectedUserName); }, "No user is present by this username!");



        }
        [Test]
        [TestCase(17)]
        [TestCase(200_000_000_000_000)]
        public void FindByID_Method_ShouldFindUsers_ByID(long id)
        {
            Person[] people =
       {
            new Person(1, "Pesho"),
            new Person(2, "Gosho"),
            new Person(3, "Ivan_Ivan"),
            new Person(4, "Pesho_ivanov"),
            new Person(5, "Gosho_Naskov"),
            new Person(6, "Pesh-Peshov"),
            new Person(17, "Ivan_Kaloqnov"),
            new Person(8, "Ivan_Draganchov"),
            new Person(9, "Asen"),
            new Person(10, "Jivko"),
            new Person(200_000_000_000_000, "Toshko")
        };

            database = new Database(people);
            long expectedID = id;
           
            long actualResultForId = database.FindById(id).Id;
            Assert.AreEqual(expectedID, actualResultForId);

        }
        [Test]
        [TestCase(-17)]
        [TestCase(-200_000_000_000_000)]
        public void FindByID_Method_ShouldThrowException_WhenID_IsNegativeNumber(long id)
        {
            Person[] people =
       {
            new Person(1, "Pesho"),
            new Person(2, "Gosho"),
            new Person(3, "Ivan_Ivan"),
            new Person(4, "Pesho_ivanov"),
            new Person(5, "Gosho_Naskov"),
            new Person(6, "Pesh-Peshov"),
            new Person(17, "Ivan_Kaloqnov"),
            new Person(8, "Ivan_Draganchov"),
            new Person(9, "Asen"),
            new Person(10, "Jivko"),
            new Person(200_000_000_000_000, "Toshko")
        };

            database = new Database(people);
            Assert.Throws<ArgumentOutOfRangeException>(() => { database.FindById(id); }, "Id should be a positive number!");

        }
        [Test]
        [TestCase(78)]
        [TestCase(19)]
        [TestCase(0)]
        public void FindByID_Method_ShouldThrowExeption_WhenID_IsNotFound(long expectedId)
        {
            Person[] people =
       {
            new Person(1, "Pesho"),
            new Person(2, "Gosho"),
            new Person(3, "Ivan_Ivan"),
            new Person(4, "Pesho_ivanov"),
            new Person(5, "Gosho_Naskov"),
            new Person(6, "Pesh-Peshov"),
            new Person(7, "Ivan_Kaloqnov"),
            new Person(8, "Ivan_Draganchov"),
            new Person(9, "Asen"),
            new Person(10, "Jivko"),
            new Person(11, "Toshko")
        };

            database = new Database(people);


            Assert.Throws<InvalidOperationException>(() => { database.FindById(expectedId); }, "No user is present by this ID!");



        }
    }
}