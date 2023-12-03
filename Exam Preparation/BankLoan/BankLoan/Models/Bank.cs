using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        
        private string name;
        private List<ILoan> loans;
        private List<IClient> clients;
        //ctor
        protected Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            loans = new List<ILoan>();
            clients = new List<IClient>();
                
        }

        public string Name
        {
            get { return name; }
           private  set 
            { if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }
                name = value; 
            }
        }

        public int Capacity {get; private set; }


        public IReadOnlyCollection<ILoan> Loans => loans;

        public IReadOnlyCollection<IClient> Clients => clients;

        public void AddClient(IClient Client)
        {
            if (clients.Count < this.Capacity)
            {
                clients.Add(Client);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
            }
        }

        public void AddLoan(ILoan loan)
        {
            loans.Add(loan);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.Name}, Type: {this.GetType().Name}");
            if (clients.Count == 0)
            {
                sb.AppendLine($"Clients: none");
            }
            else
            {
                sb.Append($"Clients: ");
                sb.AppendLine(string.Join(", ", clients.Select(c => c.Name)));//тук не съм сигурна???
            }
            sb.AppendLine($"Loans: {loans.Count}, Sum of Rates: {SumRates()}");


            return sb.ToString().Trim();
        }

        public void RemoveClient(IClient Client)// може би трябва да проверя за такъв клиент в списъка???
        {
            clients.Remove(Client);
        }

        public double SumRates()
        {
            double sumOfRates = loans.Sum(l => l.InterestRate);
            return sumOfRates;
        }
        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine($"Name: {this.Name}, Type: {this.GetType().Name}");
        //    if (clients.Count == 0)
        //    {
        //        sb.AppendLine($" Clients: none");
        //    }
        //    else
        //    {
        //        sb.AppendLine(string.Join(", ", clients.Select(c => c.Name.ToList())));//тук не съм сигурна???
        //    }
        //    sb.AppendLine($"Loans: {loans.Count}, Sum of Rates: {SumRates()}");


        //    return sb.ToString().Trim();
        //}
    }
}
