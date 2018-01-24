using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseReview
{
    public class UserRepo
    {
        public static Dictionary<string, User> users;
        public event EventHandler<TestEventArg> UserAded;

        public void OnUserAdd()
        {
            if (UserAded !=null)
            {
                UserAded(this, new TestEventArg());
                Console.WriteLine(" we raise An Event ");
            }
        }
        static UserRepo()
        {
            users = new Dictionary<string, User>();
        }

        public  void Add(User user)
        {
            users.Add(user.FirstName, user);
        }
        public  void ShowUsers()
        {
            foreach (var item in users)
            {
                Console.WriteLine($"{item.Value.FirstName} - {item.Value.LastName}");
            }
        }


    }
}
