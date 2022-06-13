using InventoryApplication.Models;
using InventoryApplication.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace InventoryApplication.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Record> List { get; set; } = new ObservableCollection<Record>();

    }
}
