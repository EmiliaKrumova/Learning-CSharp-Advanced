namespace Money_Transactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int,double> bankAccounts = new Dictionary<int,double>();
            string[] pairs = Console.ReadLine().Split(",",StringSplitOptions.RemoveEmptyEntries);
            foreach (string pair in pairs)
            {
                string[] accountINFO = pair.Split("-");
                int account = int.Parse(accountINFO[0]);
                double cash = double.Parse(accountINFO[1]);
                bankAccounts[account] = cash;
            }
            string command;
            while((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split();
                string realCommand = tokens[0];
                int account = int.Parse(tokens[1]);
                double sumToDeposit = double.Parse(tokens[2]);
                try
                {
                    IsValidCommand(realCommand);
                    int validAccount = IsValidAccount(bankAccounts, account);

                    if(realCommand== "Deposit")
                    {
                        
                        bankAccounts = CashIN(bankAccounts, validAccount,sumToDeposit);
                        Console.WriteLine($"Account {validAccount} has new balance: {bankAccounts[validAccount]:f2}");

                    }else if(realCommand== "Withdraw")
                    {
                        bankAccounts = CashOut(bankAccounts, validAccount,sumToDeposit);
                        Console.WriteLine($"Account {validAccount} has new balance: {bankAccounts[validAccount]:f2}");
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }finally { Console.WriteLine("Enter another command"); }
            }
            
        }
        public static bool IsValidCommand(string realCommand)
        {
            List<string> commands = new List<string>() { "Deposit", "Withdraw" };

            if(!commands.Contains(realCommand))
            {
                throw new InvalidOperationException("Invalid command!");
            }
            return true;
        }
        public static int IsValidAccount(Dictionary<int,double> bankAccounts,int account)
        {
            if(!bankAccounts.ContainsKey(account))
            {
                throw new ArgumentException("Invalid account!");
            }
            return account;
        }
        public static Dictionary<int,double> CashOut(Dictionary<int,double> bankAccounts,int account, double cash)
        {
            if (bankAccounts[account]<cash)
            {
                throw new ArithmeticException("Insufficient balance!");
            }
            else
            {
                bankAccounts[account] -= cash;
            }
            return bankAccounts;
        }
        public static Dictionary<int, double> CashIN(Dictionary<int, double> bankAccounts, int account, double cash)
        {           
            
                bankAccounts[account] += cash;
            
            return bankAccounts;
        }
    }
}