using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReview
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter a Number : ");
            int num=11;
            int k;
            k = 0;
            for (int i = 1; i <= num / 2; i++)
            {
                if (num % i == 0)
                {
                    k++;
                }
            }
            if (k == 2)
            {
                Console.WriteLine("Entered Number is a Prime Number and the Largest Factor is {0}", num);
            }
            else
            {
                Console.WriteLine("Not a Prime Number");
            }
            Console.ReadLine();


            var person1 = new UnemployedPerson("ZANOU", "Alain", 30, DateTime.Parse("20/10/1988"));
            var person2 = new StudentPerson("AGUEH", "Hosny", 20, DateTime.Parse("20/10/1998"));
            IBank societeGenerale = new Bank("Societe Generale");
            IBank BNP = new Bank("BNP");
            societeGenerale.AccountAdded += Notifications;
            BNP.AccountAdded += Notifications;

            societeGenerale.CreateAccount(person1);
            BNP.CreateAccount(person1);
            societeGenerale.CreateAccount(person2);

            

            societeGenerale.CreditAccount(person1, 1254.25);

            Console.WriteLine(societeGenerale);
            Console.WriteLine("Montant après un mois : "+societeGenerale.GetAmountAfterAMonth(person1));
            BNP.CreditAccount(person1, 3254.25);
            BNP.CreditAccount(person1, 10);
            Console.WriteLine(BNP);
            BNP.DebitAccount(person1, 1200);
            Console.WriteLine(BNP);
            Console.ReadKey();
        }

        private static void Notifications(object sender, BankEventArg e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
