using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseReview
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] array = new int[4][];

            var Enume = Enumerable.Range(102, 40);
            User user = new User("DA SILVA","Sahobau");
            User user1 = new User("DABAS", "Ernic");
            UserRepo userRepo = new UserRepo();
            userRepo.Add(user);
            userRepo.Add(user1);
            userRepo.ShowUsers();

            User user2 = new User("NURIU", "Hulda");
            UserRepo userRepo1 = new UserRepo();
            Console.WriteLine(user1.Equals(userRepo));
            userRepo1.UserAded += test;
            userRepo1.OnUserAdd();

            userRepo1.Add(user2);

            userRepo1.ShowUsers();
            Console.ReadLine();



        }

        private static void test(Object obj, EventArgs eventArgs)
        {
            Console.WriteLine(" On Test");
        }
    }
}
