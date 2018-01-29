using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReview
{
    public class Bank :IBank
    {
        private Dictionary<Person,Account> accounts{ get; set; }
        public string Name { get; internal set; }

        public event EventHandler<BankEventArg> AccountAdded;

        public Bank(string name)
        {
            Name = name;
            accounts = new Dictionary<Person, Account>();
        }

        public void CreateAccount(Person person)
        {
            if (!AccountExist(person)) {
                accounts.Add(person, new Account());
                OnAccountAdded(this, new BankEventArg(person.ToString()+" create new account at "+Name));
            }

        }
        public double GetAmountAfterAMonth(Person p)
        {
            if (AccountExist(p))
            {
                var pricer = BankPricerRepo.GetPricer(p.Statut);
                var currentBalance = GetBalance(p);
                var reduction = pricer.GetAgio() * currentBalance;
                return currentBalance -=reduction ;
            }
            return default(double);
        }

        public double GetBalance(Person p)
        {
            return accounts[p].Amount;
        }

        public void DeleteAccount(Person person)
        {
            if (AccountExist(person))
                accounts.Remove(person);

            OnAccountAdded(this, new BankEventArg(" Account "+person.ToString() + " is remove from Bank " + Name));
        }
        public bool AccountExist(Person person)
        {
            return accounts.ContainsKey(person) ? true : false;
        }

        public void CreditAccount(Person person, Double amount)
        {
            if (AccountExist(person))
                accounts[person].Amount+=amount;

            OnAccountAdded(this, new BankEventArg(person.ToString() + " credit " + amount+" in "+Name+" account => new balance is "+ GetBalance(person)));
        }
        public void DebitAccount(Person person, Double amount)
        {
            if (AccountExist(person))
                accounts[person].Amount -= amount;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"\n{Name} Bilan :\n");
            foreach (var item in accounts)
            {
                stringBuilder.Append($"{item.Key} => {item.Value.Amount} \n");

            }
            return stringBuilder.ToString();
        }
        private void OnAccountAdded(Object obj, BankEventArg bankEventArg)
        {
            if (AccountAdded != null)
            {
                AccountAdded(obj,bankEventArg);
            }
        }
    }
}
