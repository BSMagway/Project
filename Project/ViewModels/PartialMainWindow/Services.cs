using Project.Interfaces.Services;
using ProjectCommon.Models;
using ProjectCommon.ViewModelBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    internal partial class MainWindowViewModel : ViewModel
    {
        IWorkWithBDGeneric<Customer> _customerDBService;

        IWorkWithBDGeneric<MoistureSoilTest> _moistureSoilTestDBService;

        IWorkWithBDGeneric<FullShortListTests> _fullShortListTestDBService;
    }
}
