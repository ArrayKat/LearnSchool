using Avalonia.Controls;
using LernSchool.Models;
using ReactiveUI;

namespace LernSchool.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public static _43pSchool9Context myConnection = new _43pSchool9Context();
        public static MainWindowViewModel Instance;
        public MainWindowViewModel() { 
            Instance = this;
        }
        UserControl _pageContent = new ShowService();
        public UserControl PageContent { get => _pageContent; set => this.RaiseAndSetIfChanged(ref _pageContent, value); }
        
    }
}
