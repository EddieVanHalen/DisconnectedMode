using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using DisconnectedMode.Messages;
using Microsoft.Extensions.DependencyInjection;

namespace DisconnectedMode.ViewModel;

[INotifyPropertyChanged]
public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty] private BaseViewModel _currentViewModel;

    public MainViewModel()
    {
        WeakReferenceMessenger.Default.Register<ChangeViewModelMessage>(this,(sender, message) =>
        {
            CurrentViewModel = message.ViewModel;
        });

        var model = App.Provider.GetService<MainPageViewModel>()!;
        var message = new ChangeViewModelMessage(model);
        WeakReferenceMessenger.Default.Send<ChangeViewModelMessage>(message);
    }
}