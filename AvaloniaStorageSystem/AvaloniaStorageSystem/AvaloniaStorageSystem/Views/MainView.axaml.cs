using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Logging;
using AvaloniaStorageSystem.ViewModels;

namespace AvaloniaStorageSystem.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }


    private void SelectingItemsControl_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        Debug.WriteLine("SELECTION CHANGED");
        var vm = this.DataContext as MainViewModel;
        //GET WHICH ITEM IS SELECTED
        var Item = (sender as ComboBox).DataContext as StorageItem;
        Debug.WriteLine("Selected Item: " + Item.Name);
        //GET WHICH CATEGORY IS SELECTED
        var Category = vm.Categories[Item.CategoryIdx];
        Debug.WriteLine("Selected Category: " + Category.Name);
        Item.CriticalCount = Category.CriticalCount;
        Item.IsCritical = Item.Count <= Item.CriticalCount;
    }


    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        var vm = this.DataContext as MainViewModel;
        var Name = addName.Text;
        var Category = vm.Categories[addCategory.SelectedIndex];
        var Count = int.Parse(addCount.Text);
        vm.Items.Add(new StorageItem(Name, addCategory.SelectedIndex, Count, Category));
        addName.Text = "";
        addCount.Text = "";
    }

    private void CategoryButton_OnClick(object? sender, RoutedEventArgs e)
    {
        var vm = this.DataContext as MainViewModel;
        var Name = newCategory.Text;
        var CriticalCount = int.Parse(newCritical.Text);
        vm.Categories.Add(new Category(Name, CriticalCount));
        newCategory.Text = "";
        newCritical.Text = "";
    }

    private void Save(object? sender, RoutedEventArgs e)
    {
        var vm = this.DataContext as MainViewModel;
        vm.Save();
    }
}