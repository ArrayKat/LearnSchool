using LernSchool.Models;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
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

        public async void DeleteService(int idService) {
            ButtonResult result = await MessageBoxManager.GetMessageBoxStandard("Сообщение", "Хотите удалить данную услугу?", ButtonEnum.YesNo).ShowAsync();
            if (result == ButtonResult.Yes) {
                Service deleteService = MainWindowViewModel.myConnection.Services.FirstOrDefault(s => s.Id == idService);
                List<ClientService> serviceClient = MainWindowViewModel.myConnection.ClientServices.Where(x => x.ServiceId == idService).ToList();
                //если на услугу никто не записан - список пустой, занчит можно удалять
                bool isClientRecordedService = serviceClient.Count() != 0 ? true : false;
                if (isClientRecordedService)
                {
                    MainWindowViewModel.myConnection.Services.Remove(deleteService);
                    MainWindowViewModel.myConnection.SaveChanges();
                    MainWindowViewModel.Instance.PageContent = new ShowService();
                }
            }
            
        }

        public void ChangeService(int id) {
            MainWindowViewModel.Instance.PageContent = new AddChangeServices(id);
        }
        
    }
}
