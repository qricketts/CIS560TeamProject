using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskData.KioskModels
{
    public class Person
    {
        private string _name; 
        public string Name
        {
            get => _name;
            set => _name = value; 
        }

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
