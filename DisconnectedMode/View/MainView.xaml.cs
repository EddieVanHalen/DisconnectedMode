using System.Windows;
using DisconnectedMode.ViewModel;

namespace DisconnectedMode.View;

public partial class MainView : Window
{
    public MainView(MainViewModel mainViewModel)
    {
        InitializeComponent();

        DataContext = mainViewModel;
    }
}