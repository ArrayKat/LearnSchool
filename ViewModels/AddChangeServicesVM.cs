using LernSchool.Models;
using MsBox.Avalonia;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MsBox.Avalonia.Enums;
using Avalonia.Data.Converters;

namespace LernSchool.ViewModels
{
    internal class AddChangeServicesVM:ViewModelBase
    {
        Service? currentService;
        public Service CurrentService { get => currentService; set => this.RaiseAndSetIfChanged(ref currentService, value); }

        //для того, что бы показывать/скрывать поле id
        bool _isVisibleId;
        public bool IsVisibleId { get => _isVisibleId; set => this.RaiseAndSetIfChanged(ref _isVisibleId, value); }
        //имя страницы ("Добавление", "Редактирование")
        string _namePage = "";
        public string NamePage => _namePage;

        

        public AddChangeServicesVM(int idService)
        {
            CurrentService = MainWindowViewModel.myConnection.Services.FirstOrDefault(x => x.Id == idService);
            _isVisibleId = true;
            _namePage = "Редактирование";
        }
        public AddChangeServicesVM()
        {
            CurrentService = new Service();
            _isVisibleId = false;
            _namePage = "Добавление";
        }
        public void ToBackPage() {
            MainWindowViewModel.Instance.PageContent = new ShowService();
        }

        public async void SaveChange() {
            
            if (CurrentService.Id == 0) //добавление
            {
                CheckData();
                //Уникальность названия услуги
                Service TitleDB = MainWindowViewModel.myConnection.Services.FirstOrDefault(x => x.Title.ToLower() == CurrentService.Title.ToLower());
                if (TitleDB == null)
                {
                    ButtonResult result = await MessageBoxManager.GetMessageBoxStandard("Сообщение", "Хотите добавить новую услугу?", ButtonEnum.YesNo).ShowAsync();
                    if (result == ButtonResult.Yes)
                    {
                        MainWindowViewModel.myConnection.Services.Add(CurrentService);
                        MainWindowViewModel.myConnection.SaveChanges();
                        MainWindowViewModel.Instance.PageContent = new ShowService();
                    }
                    else
                    {
                        MainWindowViewModel.Instance.PageContent = new ShowService();
                    }
                }
                else await MessageBoxManager.GetMessageBoxStandard("Сообщение", "Такое название услуги уже существует", ButtonEnum.Ok).ShowAsync();

            }
            else // редактирование
            {
                CheckData();
                ButtonResult result = await MessageBoxManager.GetMessageBoxStandard("Сообщение", "Хотите сохранить изменения?", ButtonEnum.YesNo).ShowAsync();
                if (result == ButtonResult.Yes)
                {
                    MainWindowViewModel.myConnection.SaveChanges();
                    MainWindowViewModel.Instance.PageContent = new ShowService();
                }
                else
                {
                    MainWindowViewModel.Instance.PageContent = new ShowService();
                }
            }
        }

        public async void CheckData() {
            //проверка на не пустые поля
            if (!string.IsNullOrEmpty(CurrentService.Title) || !string.IsNullOrEmpty(CurrentService.Cost.ToString()) || !string.IsNullOrEmpty(CurrentService.DurationInSeconds.ToString()))
            {
                //длительность оказания услуги не отрицательна и не более 4 часов (240 минут)
                if (CurrentService.DurationInMinutes < 0 && CurrentService.DurationInMinutes > 240) await MessageBoxManager.GetMessageBoxStandard("Сообщение", "Длительность оказания услуги не может быть более 4 часов или отрицательна.", ButtonEnum.Ok).ShowAsync();
            }
            else await MessageBoxManager.GetMessageBoxStandard("Сообщение", "Не все поля заполнены", ButtonEnum.Ok).ShowAsync();
        }
    }
}
