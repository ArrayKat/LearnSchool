using LernSchool.Models;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LernSchool.ViewModels
{
    internal class ShowServiceVM : ViewModelBase
    {
        List<Service> _listServices;

        public List<Service> ListServices { get => _listServices; set => this.RaiseAndSetIfChanged(ref _listServices, value); }

        int _countListServices;
        int _countAllServices;
        public ShowServiceVM()
        {
            ListServices = MainWindowViewModel.myConnection.Services.ToList();
            _countListServices = _listServices.Count;
            _countAllServices = MainWindowViewModel.myConnection.Services.Count();
        }
        public int CountAllServices { get => _countAllServices; set => this.RaiseAndSetIfChanged(ref _countAllServices, value); }
        public int CountListServices { get => _countListServices; set => this.RaiseAndSetIfChanged(ref _countListServices, value); }

        #region Change, delete
        public async void DeleteService(int idService)
        {
            ButtonResult result = await MessageBoxManager.GetMessageBoxStandard("Сообщение", "Хотите удалить данную услугу?", ButtonEnum.YesNo).ShowAsync();
            if (result == ButtonResult.Yes)
            {
                Service deleteService = MainWindowViewModel.myConnection.Services.FirstOrDefault(s => s.Id == idService);
                List<ClientService> serviceClient = MainWindowViewModel.myConnection.ClientServices.Where(x => x.ServiceId == idService).ToList();
                //если на услугу никто не записан - список пустой, занчит можно удалять
                bool isClientRecordedService = serviceClient.Count() != 0 ? false : true;
                if (isClientRecordedService)
                {
                    MainWindowViewModel.myConnection.Services.Remove(deleteService);
                    MainWindowViewModel.myConnection.SaveChanges();
                    MainWindowViewModel.Instance.PageContent = new ShowService();
                }
            }

        }

        public void ChangeService(int id)
        {
            MainWindowViewModel.Instance.PageContent = new AddChangeServices(id);
        }
        public void AddService() {
            MainWindowViewModel.Instance.PageContent = new AddChangeServices();
        }
        #endregion

        string _searchNameDesc = "";
        int _sortCostIndex = 0;
        int _filterDiscountIndex = 0;
        public string SearchNameDesc { get => _searchNameDesc; set { this.RaiseAndSetIfChanged(ref _searchNameDesc, value); AllFilters(); } }
        public int SortCostIndex { get => _sortCostIndex; set { _sortCostIndex = value; AllFilters(); } }
        public int FilterDiscountIndex { get => _filterDiscountIndex; set { this.RaiseAndSetIfChanged(ref _filterDiscountIndex, value); AllFilters(); } }

       
        
        
        void AllFilters()
        {
            //обновляем список сервисов
            ListServices = MainWindowViewModel.myConnection.Services.ToList();
            CountAllServices = MainWindowViewModel.myConnection.Services.Count();
            //для поиска по имени и описанию (сработает, если поле ввода не пустое)
            if (!string.IsNullOrEmpty(_searchNameDesc))
            {
                //Выбираем все сервисы, в которых название или описание (маленькими буквами) содержит строчку введенную пользователем
                ListServices = ListServices.Where(x => x.Title.ToLower().Contains(_searchNameDesc.ToLower()) || x.Description.ToLower().Contains(_searchNameDesc.ToLower())).ToList();
            }

            switch (_sortCostIndex)
            {
                case 1: ListServices = ListServices.OrderBy(x => x.CostResult).ToList(); break;
                case 2: ListServices = ListServices.OrderByDescending(x => x.CostResult).ToList(); break;
                default: ListServices = ListServices.ToList(); break;
            }

            switch (_filterDiscountIndex)
            {
                case 1: ListServices = ListServices.Where(x => x.DiscountInt >= 0 && x.DiscountInt < 5).ToList(); break;
                case 2: ListServices = ListServices.Where(x => x.DiscountInt >= 5 && x.DiscountInt < 15).ToList(); break;
                case 3: ListServices = ListServices.Where(x => x.DiscountInt >= 15 && x.DiscountInt < 30).ToList(); break;
                case 4: ListServices = ListServices.Where(x => x.DiscountInt >= 30 && x.DiscountInt < 70).ToList(); break;
                case 5: ListServices = ListServices.Where(x => x.DiscountInt >= 70 && x.DiscountInt < 100).ToList(); break;
                default: ListServices = ListServices.ToList(); break;
            }
            CountListServices = ListServices.Count();
            


        }

        string _adminCode = "";
        bool _isVisibleAdmin = false;
        public string AdminCode { get => _adminCode; set { this.RaiseAndSetIfChanged(ref _adminCode, value); } }

        public bool IsVisibleAdmin { get => _isVisibleAdmin; set => this.RaiseAndSetIfChanged(ref _isVisibleAdmin, value); }
        


        //public bool CheckAdmin => Convert.ToInt32(_adminCode)==000000 ? false : true;
        public void CheckAdmin(){ IsVisibleAdmin = AdminCode == "00000" ? true : false;  }

    }
}
