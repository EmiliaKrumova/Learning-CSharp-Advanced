using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankLoan.Repositories
{
    public class BankRepository : IRepository<IBank>
    {
        private List<IBank> models;

        public BankRepository()
        {
            this.models = new List<IBank>();
        }
        public IReadOnlyCollection<IBank> Models
            => this.models.AsReadOnly();

        public void AddModel(IBank model)
            => this.models.Add(model);

        public IBank FirstModel(string name)
            => this.models.FirstOrDefault(m => m.Name == name);

        public bool RemoveModel(IBank model)
            => this.models.Remove(model);
    }
}
