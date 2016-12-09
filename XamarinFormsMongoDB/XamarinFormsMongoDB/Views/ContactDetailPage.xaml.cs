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
    public partial class ContactDetailPage : ContentPage
    {
        private Contact Contact;
        private ServiceClient client = new ServiceClient();
        public ContactDetailPage(Contact contact)
        {
            this.Contact = contact;

            InitializeComponent();

            this.Padding = Device.OnPlatform(
                new Thickness(10, 20, 10, 10),//IOS
                new Thickness(10),//Android
                new Thickness(10));

            nameEntry.Text = contact.Name;
            lastNameEntry.Text = contact.LastName;

            saveButton.Clicked += SaveButton_Clicked;
            deleteButton.Clicked += DeleteButton_Clicked;
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var res = await client.DeleteContactAsync(this.Contact.Id);
            await DisplayAlert("Delete Contact", "Contact deleted", "Ok");
            await Navigation.PopAsync();
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            Contact contact = new Contact()
            {
                Id = this.Contact.Id,
                Name = nameEntry.Text,
                LastName = lastNameEntry.Text
            };
            var res = await client.UpdateContactAsync(contact);
            await DisplayAlert("Save Changes", "Contact updated", "Ok");
            await Navigation.PopAsync();
        }
    }
}
