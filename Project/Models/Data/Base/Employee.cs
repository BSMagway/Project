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
    }
}
