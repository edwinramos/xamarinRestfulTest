using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinFormsMongoDB.Models.Entities;
using XamarinFormsMongoDB.ViewModels;

namespace XamarinFormsMongoDB.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.Padding = Device.OnPlatform(
                new Thickness(10, 20, 10, 10),//IOS
                new Thickness(10),//Android
                new Thickness(10));

            BindingContext = new ContactVM();
<<<<<<< HEAD
            contactListView.ItemSelected += List_ItemSelected;
            contactListView.BeginRefresh();
        }

        protected override void OnAppearing()
        {
            nameEntry.Text = "";
            lastNameEntry.Text = "";
            contactListView.BeginRefresh();
            base.OnAppearing();
=======
            list.ItemSelected += List_ItemSelected;
            list.BeginRefresh();
>>>>>>> ade5b35fc8ccbfb9d23a591fadc1dd464ecfe2db
        }

        private async void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ContactDetailPage((Contact)e.SelectedItem));
        }
    }
}
