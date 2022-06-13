using InventoryApplication.Models;
using InventoryApplication.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditRecord : ContentPage
    {
        public Record record;
        public async Task getItemAsync(Record item)
        {
            RecordService db = await RecordService.Instance;
            await db.GetItem(item);

        }

        public async Task deleteItemAsync(Record item)
        {
            RecordService db = await RecordService.Instance;
            await db.RemoveRecord(item);
        }

        public async Task updateItemAsync(Record item)
        {
            RecordService db = await RecordService.Instance;
            await db.UpdateRecord(item);
        }

        async void OnAlertFail(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "Failed to edit record.Please check your information.", "OK");
        }

        async void deletePopup(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "Chosen record has been successfully deleted.", "OK");
        }

        async void editPopup(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "Changes saved successfully.", "OK");
        }

        public EditRecord()
        {
            InitializeComponent();
        }

        public EditRecord(Record myRecord)
        {
            InitializeComponent();
            getItemAsync(myRecord);
            record = myRecord;
            Name.Text = myRecord.Name;
            Surname.Text = myRecord.Surname;
            Producer.Text = myRecord.Producer;
            Model.Text = myRecord.Model;

            var ramStr = substringFunc(myRecord.Ram);
            RAM.Text = ramStr[0];
            ramPicker.SelectedIndex = ramStr[1] == "GB" ? 0 : 1;

            var hddStr = substringFunc(myRecord.Hdd);
            HDD.Text = hddStr[0];
            hddPicker.SelectedIndex = hddStr[1] == "GB" ? 0 : 1;

            var ssdStr = substringFunc(myRecord.Ssd);
            SSD.Text = ssdStr[0];
            ssdPicker.SelectedIndex = ssdStr[1] == "GB" ? 0 : 1;

        }

        public string[] substringFunc(string str)
        {
            if (str.Length > 2)
            {
                string str1 = str.Substring(0, str.Length - 2);
                string str2 = str.Substring(str.Length - 2, 2);
                string[] strArray = { str1, str2 };
                return strArray;
            }
            string[] strArray2 = { "0", "GB" };
            return strArray2;
        }

        private void editButton_Clicked(object sender, EventArgs e)
        {
            if (editButton.Text == "Edit")
            {
                entries.IsEnabled = true;
                editButton.Text = "Save";
                editInfo.IsVisible = true;

            }
            else
            {
                if (String.IsNullOrWhiteSpace(Name.Text) || String.IsNullOrWhiteSpace(Surname.Text) || String.IsNullOrWhiteSpace(Producer.Text) || String.IsNullOrWhiteSpace(Model.Text) ||
                String.IsNullOrWhiteSpace(RAM.Text) || String.IsNullOrWhiteSpace(ramPicker.SelectedItem.ToString()))
                {
                    OnAlertFail(sender, e);
                }
                else
                {
                    record.Name = Name.Text;
                    record.Surname = Surname.Text;
                    record.Producer = Producer.Text;
                    record.Model = Model.Text;

                    editPopup(sender, e);
                    editInfo.IsVisible = false;
                    editButton.Text = "Edit";
                    updateItemAsync(record);
                }
            }
        }

        private async void deleteButton_Clicked(object sender, EventArgs e)
        {
            await deleteItemAsync(record);
            deletePopup(sender, e);
            App.Current.MainPage = new MainPage();
        }

        private void RAM_TextChanged(object sender, TextChangedEventArgs e)
        {
            string pickerRam = ramPicker.SelectedIndex == 0 ? "GB" : "TB";
            record.Ram = e.NewTextValue.ToString() + pickerRam;
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }

        private void HDD_TextChanged(object sender, TextChangedEventArgs e)
        {
            string pickerHdd = hddPicker.SelectedIndex == 0 ? "GB" : "TB";
            record.Hdd = e.NewTextValue.ToString() + pickerHdd;
        }

        private void SSD_TextChanged(object sender, TextChangedEventArgs e)
        {
            string pickerSsd = ssdPicker.SelectedIndex == 0 ? "GB" : "TB";
            record.Ssd = e.NewTextValue.ToString() + pickerSsd ;
        }

        private void ssdPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pickerSsd = ssdPicker.SelectedIndex == 0 ? "GB" : "TB";
            record.Ssd = SSD.Text + pickerSsd;
        }

        private void hddPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pickerHdd = hddPicker.SelectedIndex == 0 ? "GB" : "TB";
            record.Hdd = HDD.Text + pickerHdd;
        }

        private void ramPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pickerRam = ramPicker.SelectedIndex == 0 ? "GB" : "TB";
            record.Ram = RAM.Text + pickerRam;
        }
    }
}