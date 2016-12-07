using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinFormsMongoDB.Models.Entities;
using XamarinFormsMongoDB.Models.Services;

namespace XamarinFormsMongoDB.Views
{
    public partial class MainPage : ContentPage
    {
        ServiceClient client;

        public MainPage()
        {
            InitializeComponent();
            addButton.Clicked += AddButton_Clicked;
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            client = new ServiceClient();
            Contact contact = new Contact();
            contact.Name = nameEntry.Text;
            contact.LastName = lastNameEntry.Text;

            await client.CreateContactAsync(contact);
        }
    }
}
