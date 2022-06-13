using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApplication.Models;
using InventoryApplication.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewRecord : ContentPage
    {
        public NewRecord()
        {
            InitializeComponent();
        }

        async void OnAlertFail(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "Failed to create record.Please check your information.", "OK");
        }

        async void OnAlertSuccess(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "The new record has been successfully added.", "OK");
        }

        private async void addButton_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Name.Text) || String.IsNullOrWhiteSpace(Surname.Text) || String.IsNullOrWhiteSpace(Producer.Text) || String.IsNullOrWhiteSpace(Model.Text) ||
                String.IsNullOrWhiteSpace(RAM.Text) || String.IsNullOrWhiteSpace(ramPicker.SelectedItem.ToString()))
            {
                OnAlertFail(sender, e);
            }
            else
            {
                OnAlertSuccess(sender, e);
                var record = new Record()
                {
                    Name = Name.Text,
                    Surname = Surname.Text,
                    Producer = Producer.Text,
                    Model = Model.Text,
                    Ram = RAM.Text + ramPicker.SelectedItem.ToString(),
                    Hdd = (String.IsNullOrWhiteSpace(HDD.Text)) ? "0" : HDD.Text + hddPicker.SelectedItem.ToString(),
                    Ssd = (String.IsNullOrWhiteSpace(SSD.Text)) ? "0" : SSD.Text + ssdPicker.SelectedItem.ToString()
                };

                var newRecord = (NewRecord)BindingContext;
                RecordService db = await RecordService.Instance;
                await db.AddRecord(record);

                //Task task = RecordService.AddRecord(record);
                Name.Text = "";
                Surname.Text = "";
                Producer.Text = "";
                Model.Text = "";
                RAM.Text = "";
                HDD.Text = "";
                SSD.Text = "";
            }
        }

        private void resetButton_Clicked(object sender, EventArgs e)
        {
            Name.Text = "";
            Surname.Text = "";
            Producer.Text = "";
            Model.Text = "";
            RAM.Text = "";
            HDD.Text = "";
            SSD.Text = "";
            ramPicker.SelectedIndex = 0;
            hddPicker.SelectedIndex = 0;
            ssdPicker.SelectedIndex = 0;
        }


    }
}