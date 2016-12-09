using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinFormsMongoDB.Models.Entities;
using XamarinFormsMongoDB.Models.Services;
using XamarinFormsMongoDB.ViewModels;

namespace XamarinFormsMongoDB.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ContactVM();
            //list.ItemSelected += List_ItemSelected;
        }

        //private async void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    await Navigation.PushAsync(new ContactDetailPage((Contact)e.SelectedItem));
        //}
    }
}
