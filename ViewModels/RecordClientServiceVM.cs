using LernSchool.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LernSchool.ViewModels
{
    internal class RecordClientServiceVM : ViewModelBase
    {
        Service currentService;
        List<Client> _listClients;
        int time = 0;
        public Service CurrentService => currentService;

        public List<Client> ListClients { get => _listClients; set =>this.RaiseAndSetIfChanged(ref _listClients, value); }
        public int Time { get => time; set =>this.RaiseAndSetIfChanged(ref time, value); }

        public RecordClientServiceVM(Service service) { 
            currentService = service;
            _listClients = MainWindowViewModel.myConnection.Clients.ToList();
        }

        public void CheckData() { 
            int str = Time;
        }
    }
}
