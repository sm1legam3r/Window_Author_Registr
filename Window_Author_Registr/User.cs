using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Window_Author_Registr
{
    public class User {
        public String name;
        public String login;
        public String sex;
        public String password;

        public User(String login, String password) {
            this.login = login;
            this.password = password;
        }

        public User(String name, String login, String sex, String password) {
            this.name = name;
            this.login = login;
            this.sex = sex;
            this.password = password;
        }
    }
}
