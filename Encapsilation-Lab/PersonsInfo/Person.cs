using System;


namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (value.Length >= 3)
                {
                   this.firstName = value;
                }
                else
                {
                   throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if(value.Length>=3)
                {
                    this.lastName = value;
                }
                else
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
                this.lastName = value;
            }
        }
        public int Age
        {
            get { return age; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                age = value;
            }
        }
        public decimal Salary
        {
            get { return salary; }
            private set
            {
                if (value <0)
                {
                    throw new ArgumentException("salary cannot be less than 650 leva!");

                }
                salary = value;
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";

            //$"{this.FirstName} {this.LastName} is {this.Age} years old.";// this is solution for Task 1
        }
        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age >= 30)
            {
                Salary += Salary * percentage * 0.01m;
            }
            else
            {
                Salary += Salary * percentage * 0.01m * 0.5m;
            }
        }
    }
}
