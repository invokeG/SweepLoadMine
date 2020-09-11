using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService1
{
    public class User
    {
        public string UserName { get; set; }

        public readonly IService1Callback callback;

        public bool IsStarted { get; set; }

        public User(string userName, IService1Callback callback)
        {
            this.UserName = userName;
            this.callback = callback;
        }
    }
}