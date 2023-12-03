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
    public class LoanRepository : IRepository<ILoan>
    {
        private IList<ILoan> loans;
        //ctor
        public LoanRepository()
        {
            loans = new List<ILoan>();
            this.Models = new ReadOnlyCollection<ILoan>(loans);
        }
        public IReadOnlyCollection<ILoan> Models { get; }

        public void AddModel(ILoan model)
        {
            loans.Add(model);
        }

        public ILoan FirstModel(string name)
        {
            ILoan loanToReturn = loans.Where(l=>l.GetType().Name== name).FirstOrDefault();//???
           
            return loanToReturn;
        }

        public bool RemoveModel(ILoan model)
        {
            if (loans.Contains(model))
            {
                loans.Remove(model);
                return true;
            }
            return false;
        }
    }
}
