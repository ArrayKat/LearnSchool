using LernSchool.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LernSchool.ViewModels
{
    internal class ShowServiceVM : ViewModelBase
    {
        public List<Service> ListServices => MainWindowViewModel.myConnection.Services.ToList();

        
    }
}
