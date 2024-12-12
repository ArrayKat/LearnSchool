using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using LernSchool.Models;
using LernSchool.ViewModels;

namespace LernSchool;

public partial class RecordClientService : UserControl
{
    public RecordClientService(Service selectedService)
    {
        InitializeComponent();
        DataContext = new RecordClientServiceVM(selectedService);
    }
}