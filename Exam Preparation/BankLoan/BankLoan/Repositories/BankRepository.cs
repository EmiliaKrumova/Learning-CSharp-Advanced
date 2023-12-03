using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Repositories
{
    public class BankRepository : IRepository<IBank>
    {
        private  IList<IBank> banks;
        public IReadOnlyCollection<IBank> Models { get; }

        //ctor
        public BankRepository()
        {
            banks = new List<IBank>();
            this.Models = new ReadOnlyCollection<IBank>(banks);
        }

        public void AddModel(IBank model)
        {
            banks.Add(model);//да проверя дали тая банка не е вече в колекцията???
        }

        public IBank FirstModel(string name)
        {
            IBank bankToReturn = banks.Where(l => l.GetType().Name == name).FirstOrDefault();//???

            return bankToReturn;
        }

        public bool RemoveModel(IBank model)
        {
            if (banks.Contains(model))
            {
                banks.Remove(model);
                return true;
            }
            return false;
        }
    }
}
