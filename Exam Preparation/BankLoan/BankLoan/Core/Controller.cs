using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Repositories.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        private IRepository<ILoan> loans;
        private IRepository<IBank> banks;

        public Controller()
        {
            this.loans = new LoanRepository();
           this.banks = new BankRepository();
        }

        public string AddBank(string bankTypeName, string name)
        {
            if(bankTypeName!=nameof(BranchBank)&& bankTypeName != nameof(CentralBank))
            {
                return string.Format(ExceptionMessages.BankTypeInvalid);
            }
            IBank bank = null;
            if(bankTypeName==nameof(CentralBank))
            {
               bank = new CentralBank(name);
            }else if (bankTypeName == nameof(BranchBank))
            {
                bank = new BranchBank(name);
            }
            banks.AddModel(bank);
            return string.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName); 
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            if(clientTypeName!=nameof(Adult)&& clientTypeName != nameof(Student))
            {
                return string.Format(ExceptionMessages.ClientTypeInvalid);
            }
           IBank currBank =  banks.FirstModel(bankName);
            IClient client = null;
            if(clientTypeName==nameof(Student)) 
            {
                client = new Student(clientName,id,income);
                if(currBank.GetType().Name=="BranchBank") 
                {
                    currBank.AddClient(client);
                    return string.Format(OutputMessages.ClientAddedSuccessfully, client.GetType().Name, bankName);
                }
                return string.Format(OutputMessages.UnsuitableBank);
            }
            else
            {
                client = new Adult(clientName, id, income);
                if (currBank.GetType().Name == "CentralBank")
                {
                    currBank.AddClient(client);
                    return string.Format(OutputMessages.ClientAddedSuccessfully, client.GetType().Name, bankName);
                }
                return string.Format(OutputMessages.UnsuitableBank);
            }
        }

        public string AddLoan(string loanTypeName)
        {
           if(loanTypeName!=nameof(MortgageLoan)&& loanTypeName != nameof(StudentLoan))
            {
                return string.Format(ExceptionMessages.LoanTypeInvalid);
            }
           ILoan loan = null;
            if(loanTypeName==nameof(StudentLoan))
            {
                loan = new StudentLoan();
            }else if(loanTypeName== nameof(MortgageLoan))
            {
                loan = new MortgageLoan();
            }
            loans.AddModel(loan);
            return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
        }

        public string FinalCalculation(string bankName)
        {
            IBank currBank = banks.FirstModel(bankName);
            double sumClients = currBank.Clients.Select(cl => cl.Income).Sum();
            double sumLoans = currBank.Loans.Select(l => l.Amount).Sum();
            double finalSum = sumClients + sumLoans;
            double sum = Math.Round(finalSum,2);
            string sumFinal = sum.ToString("0.00");

            return string.Format(OutputMessages.BankFundsCalculated, bankName, sumFinal) ;
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
           
            ILoan loan = loans.FirstModel(loanTypeName);
            if(loan == null)
            {
                return string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName);
            }                      
            IBank bank = banks.FirstModel(bankName);            
             
            bank.AddLoan(loan);
            loans.RemoveModel(loan);
            return string.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
            
        }

        public string Statistics()
        {
            StringBuilder sb = new StringBuilder();
            IEnumerable<IBank> orderedbanks = banks.Models;
            foreach (var bank in orderedbanks)
            {
                sb.AppendLine(bank.GetStatistics());

            }
            return sb.ToString().Trim();
        }
    }
}
