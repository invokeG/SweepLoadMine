using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace WcfService1
{
    public class CC
    {
        public static List<User> Users { get; set; }

        public static User GetUser(string userName)
        {
            User user = null;
            foreach (var v in Users)
            {
                if (v.UserName == userName)
                {
                    user = v;
                    break;
                }
            }
            return user;
        }
    }
}