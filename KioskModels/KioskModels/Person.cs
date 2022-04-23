using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskModels.KioskModels
{
    public class Person
    {
        private string _email;
        public string Email
        {
            get => _email;
            set => _email = value;
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => _email = value; 
        }
    }
}
