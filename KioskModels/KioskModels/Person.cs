using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskData.KioskModels
{
    public class Person
    {
        private int _personId;
        public int PersonId
        {
            get => _personId;
            set => _personId = value;
        }

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
            set => _password = value; 
        }

        private DateTime _createdOn;
        public DateTime CreatedOn
        {
            get => _createdOn;
            set => _createdOn = value;
        }

        private DateTime _updatedOn;
        public DateTime UpdatedOn
        {
            get => _updatedOn;
            set => _updatedOn = value;
        }

        public Person(int personId, string name, string email, string password)
        {
            PersonId = personId;
            Name = name;
            Email = email;
            Password = password;
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
        }
    }
}
