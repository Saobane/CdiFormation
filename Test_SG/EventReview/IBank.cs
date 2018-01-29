using System;

namespace EventReview
{
    public interface IBank
    {
        event EventHandler<BankEventArg> AccountAdded;
        void CreateAccount(Person person);
        void DeleteAccount(Person person);
        bool AccountExist(Person person);
        double GetAmountAfterAMonth(Person p);
        void CreditAccount(Person person, Double amount);
        void DebitAccount(Person person, Double amount);
    }
}