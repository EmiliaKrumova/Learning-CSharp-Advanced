using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class User : IUser
    {
        
        private string firstName;
        private string lastName;
        private string drivingLicenseNumber;
        private double rating;
        private bool isBlocked;

        //ctor
        public User(string firstName, string lastName, string drivingLicenseNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DrivingLicenseNumber = drivingLicenseNumber;
            this.rating = 0;//???
            this.isBlocked = false;// ???
        }

        public string FirstName
        {
            get { return firstName; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                   throw new ArgumentException(ExceptionMessages.FirstNameNull);
                }
                firstName = value; }
        }


        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LastNameNull);
                }
                lastName = value;
            }
        }

        public double Rating => this.rating;

        public string DrivingLicenseNumber
        {
            get { return drivingLicenseNumber; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
                }
                drivingLicenseNumber = value;
            }
        }

        public bool IsBlocked => this.isBlocked;

        public void DecreaseRating()
        {
            this.rating -= 2;
            if (Rating < 0)
            {
                rating = 0;
                isBlocked = true;
            }
        }

        public void IncreaseRating()
        {
            this.rating += 0.5;
            if (rating > 10)
            {
                rating = 10;
            }
        }
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} Driving license: {this.drivingLicenseNumber} Rating: {this.rating}";
        }
    }
}
