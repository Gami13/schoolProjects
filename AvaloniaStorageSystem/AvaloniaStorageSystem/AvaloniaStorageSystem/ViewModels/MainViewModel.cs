using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avalonia;
using Avalonia.Platform;
using Avalonia.Platform.Storage;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace AvaloniaStorageSystem.ViewModels;

public class StorageItemSerialization(string name, bool isCritical, int count, int categoryIdx, int criticalCount)
{
    public string Name = name;
    public bool IsCritical = isCritical;
    public int Count = count;
    public int CategoryIdx = categoryIdx;
    public int CriticalCount = criticalCount;
}

public class StorageItem : INotifyPropertyChanged
{
    public string Name { get; set; }
    private bool _isCritical;


    public bool IsCritical
    {
        get => _isCritical;
        set
        {
            _isCritical = value;
            PropertyChanged?.Invoke(nameof(IsCritical), new PropertyChangedEventArgs(nameof(IsCritical)));
        }
    }

    private int _count;


    public int Count
    {
        get => _count;
        set
        {
            _count = value < 0 ? 0 : value;
            PropertyChanged?.Invoke(nameof(Count), new PropertyChangedEventArgs(nameof(Count)));
        }
    }

    public int CategoryIdx { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;
    public int CriticalCount { get; set; } = 0;

    public void Add()
    {
        Count += 1;
        IsCritical = Count <= CriticalCount;
    }

    public void Remove()
    {
        Count -= 1;
        IsCritical = Count <= CriticalCount;
    }

    public StorageItem(string name, int categoryIdx, int count, Category category)
    {
        Name = name;
        Count = count;
        CategoryIdx = categoryIdx;
        CriticalCount = category.CriticalCount;
    }

    public StorageItem()
    {
    }
}

public class Category(string name, int criticalCount)
{
    public string Name { get; set; } = name;
    public int CriticalCount { get; set; } = criticalCount;
}

public class MainViewModel : ViewModelBase
{
    public ObservableCollection<Category> Categories { get; set; }

    public ObservableCollection<StorageItem> Items { get; set; }


    public MainViewModel()
    {
        Categories =
        [
            new Category("Drinks", 5),
            new Category("Food", 3),
            new Category("Other", 0)
        ];
        Items =
        [
            new StorageItem("Coca-Cola 0.5L", 0, 10, Categories[0]),
            new StorageItem("Pepsi 0.5L", 0, 5, Categories[0]),
            new StorageItem("Fanta 0.5L", 0, 7, Categories[0]),
        ];
        Load();
        Debug.WriteLine("HELLO");
    }

    public void Save()
    {
        var filePath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "data.json");
        MessageBoxManager.GetMessageBoxStandard("Saved", "Data saved to " + filePath, ButtonEnum.Ok).ShowAsync();
        Debug.WriteLine("Saving to: " + filePath);
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(JsonSerializer.Serialize(Items));

            writer.WriteLine(JsonSerializer.Serialize(Categories));
        }
    }

    private void Load()
    {
        Debug.WriteLine("Loading");
        try
        {
            var filePath =
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "data.json");
            Debug.WriteLine("Loading from: " + filePath);
            if (!File.Exists(filePath)) return;
            using var reader = new StreamReader(filePath);

            var items = JsonSerializer.Deserialize<ObservableCollection<StorageItemSerialization>>(reader.ReadLine());
           
            Categories = JsonSerializer.Deserialize<ObservableCollection<Category>>(reader.ReadLine());
            var newItems = new ObservableCollection<StorageItem>();
            foreach (var item in items)
            {
                Debug.WriteLine("ITEM: " + item.Name);
                var newItem = new StorageItem
                {
                    Name = item.Name,
                    Count = item.Count,
                    CategoryIdx = item.CategoryIdx,
                    IsCritical = item.IsCritical,
                    CriticalCount = item.CriticalCount
                };
                newItems.Add(newItem);
            }

            Items = newItems;
        }
        catch (Exception e)
        {
            Debug.WriteLine("ERROR " + e.Message);
        }
    }
}