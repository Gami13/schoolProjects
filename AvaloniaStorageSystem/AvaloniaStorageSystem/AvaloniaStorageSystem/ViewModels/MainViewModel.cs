using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaStorageSystem.ViewModels;

public  class StorageItem :INotifyPropertyChanged
{
    public string Name { get; set; } 
    
    private int _count;
    public int Count
    {
        get => _count;
        set { _count = value; PropertyChanged?.Invoke(nameof(Count), new PropertyChangedEventArgs(nameof(Count))); }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public int ChangeStep { get; set; } = 1;
    public void Add(int count) => Count += count;
    public void Remove(int count) => Count -= count;
    
    public StorageItem(string name, int count)
    {
        this.Name = name;
        this.Count = count;
    }
    
    
}

public class MainViewModel : ViewModelBase
{

    public ObservableCollection<StorageItem> Items { get; }

    public MainViewModel()
    {
        var items = new List<StorageItem>
        {
            new StorageItem("Coca-Cola 0.5L", 10),
            new StorageItem("Pepsi 0.5L", 5),
            new StorageItem("Fanta 0.5L", 7),
        };
        Items = new ObservableCollection<StorageItem>(items);
       
    }

    private void OnPropertyChanged(string itemsName)
    {
        throw new System.NotImplementedException();
    }
}