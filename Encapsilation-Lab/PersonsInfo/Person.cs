using System;


namespace PersonsInfo
{
    public class Person
    {
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";

                //$"{this.FirstName} {this.LastName} is {this.Age} years old.";// this is solution for Task 1
        }
        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age >= 30)
            {
                Salary += Salary*percentage*0.01m;
            }
            else
            {
                Salary += Salary*percentage*0.01m*0.5m;
            }
        }
    }
}
