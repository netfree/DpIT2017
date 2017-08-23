using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace connect_to_ue
{
    public class User
    {
        int id;
        string email;
        string password;
        int user_type;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public int User_type
        {
            get
            {
                return user_type;
            }

            set
            {
                user_type = value;
            }
        }

        public User()
        { }



    }
}