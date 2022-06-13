using InventoryApplication.Models;
using InventoryApplication.Services;
using InventoryApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecordList : ContentPage
    {
        public RecordList()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            RecordService db = await RecordService.Instance;
            lstView.ItemsSource = await db.GetItemsAsync();
        }

        private void lstView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            
            Record myRecord = (Record)e.Item;
            var editRecord = new EditRecord(myRecord);
            App.Current.MainPage = editRecord;
        }
    }
}