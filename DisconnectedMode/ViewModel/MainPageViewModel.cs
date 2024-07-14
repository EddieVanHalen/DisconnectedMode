using System.Collections.ObjectModel;
using System.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DisconnectedMode.Extentions;
using DisconnectedMode.Interface;
using DisconnectedMode.Model;
using DisconnectedMode.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DisconnectedMode.ViewModel;

[INotifyPropertyChanged]
public partial class MainPageViewModel : BaseViewModel
{
    public IDataBase SqlDb { get; set; }

    [ObservableProperty]
    private ObservableCollection<Author> _authors;

    [ObservableProperty] private DataTable? _books;
    [ObservableProperty] private int _selectedAuthorId = -1;

    public MainPageViewModel()
    {
        var config = App.Provider.GetService<ConfigurationBuilder>()!.AddJsonFile("configuration.json").Build();

        SqlDb = new SqlDbService(config["ConnectionString"]!);

        Authors = new ObservableCollection<Author>();
    }

    [RelayCommand]
    private async Task SelectionChanged()
    {
        Books = await SqlDb.GetAllAuthorsBooksAsync(SelectedAuthorId)!;
    }

    [RelayCommand]
    private async Task GetAllAuthors()
    {
        Authors.Clear();

        var temp = await SqlDb.GetAllAuthorsAsync();

        Authors = await temp.ToObservableCollectionAsync();
    }
}
