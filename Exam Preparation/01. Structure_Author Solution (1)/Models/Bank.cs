using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string name;
        private int capacity;
        private List<ILoan> loans;
        private List<IClient> clients;

        protected Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.loans = new List<ILoan>();
            this.clients = new List<IClient>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }
                this.name = value;
            }
        }
        public int Capacity
        {
            get => capacity;
            private set => capacity = value;
        }

        public IReadOnlyCollection<ILoan> Loans => this.loans;

        public IReadOnlyCollection<IClient> Clients => this.clients;

        public void AddClient(IClient client)
        {
            if (this.Clients.Count < this.Capacity)
            {
                this.clients.Add(client);
            }
        }

        public void AddLoan(ILoan loan) => this.loans.Add(loan);

        public double SumRates()
        {
            if (this.Loans.Count == 0)
            {
                return 0;
            }
            return double.Parse(this.Loans.Select(l => l.InterestRate).Sum().ToString());
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.Name}, Type: {this.GetType().Name}");
            sb.Append($"Clients: ");

            if (this.clients.Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                var names = clients.Select(c => c.Name).ToArray();
                foreach (var client in this.clients)
                    sb.AppendLine(string.Join(" ", names));
            }

            sb.AppendLine($"Loans: {this.loans.Count}, Sum of Rates: {this.SumRates()}");

            return sb.ToString().TrimEnd();
        }

        public void RemoveClient(IClient Client) => this.clients.Remove(Client);
    }
}
