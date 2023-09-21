using Project.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Data.Base
{
    internal class Employee : ViewModel
    {
        private Guid id;
        private string login;
        private string password;
        private string firstNameEmployee;
        private string lastNameEmployee;

        public Guid Id { get => id; set => id = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public string FirstNameEmployee { get => firstNameEmployee; set => firstNameEmployee = value; }
        public string LastNameEmployee { get => lastNameEmployee; set => lastNameEmployee = value; }
    }
}
