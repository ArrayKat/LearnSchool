using LernSchool.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LernSchool.ViewModels
{
    internal class AddChangeServicesVM:ViewModelBase
    {
        Service? currentService;
        public Service CurrentService { get => currentService; set => this.RaiseAndSetIfChanged(ref currentService, value); }

        public AddChangeServicesVM(int idService)
        {
            CurrentService = MainWindowViewModel.myConnection.Services.FirstOrDefault(x => x.Id == idService);
        }
        public void ToBackPage() {
            MainWindowViewModel.Instance.PageContent = new ShowService();
        }
    }
}
