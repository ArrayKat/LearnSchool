using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using LernSchool.ViewModels;

namespace LernSchool;

public partial class AddChangeServices : UserControl
{
    public AddChangeServices(int id)
    {
        InitializeComponent();
        DataContext = new AddChangeServicesVM(id);
    }
    public AddChangeServices()
    {
        InitializeComponent();
        DataContext = new AddChangeServicesVM();
    }
}