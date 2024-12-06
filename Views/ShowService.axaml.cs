using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using LernSchool.ViewModels;

namespace LernSchool;

public partial class ShowService : UserControl
{
    public ShowService()
    {
        InitializeComponent();
        DataContext = new ShowServiceVM();
    }
}