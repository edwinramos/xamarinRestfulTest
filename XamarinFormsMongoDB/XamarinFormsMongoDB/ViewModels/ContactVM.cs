using DemoAzureOfflineSync;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using XamarinFormsMongoDB.Models.Entities;
using Xamarin.Forms;
using XamarinFormsMongoDB.Models.Services;

namespace XamarinFormsMongoDB.ViewModels
{
    public class ContactVM : ObservableBaseObject
    {
        public ObservableCollection<Contact> ContactList = new ObservableCollection<Contact>();
        public Command CreateCommand { get; set; }
        public Command Read1Command { get; set; }
        public Command ReadAllCommand { get; set; }
        public Command UpdateCommand { get; set; }
        public Command DeleteCommand { get; set; }

        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; }
        }

        private ServiceClient client = new ServiceClient();

        public ContactVM()
        {
            CreateCommand = new Command(() => Insert());
            Read1Command = new Command(() => ReadOne(Id));
            ReadAllCommand = new Command(() => ReadAll());
            UpdateCommand = new Command(() => Update());
            DeleteCommand = new Command(() => Delete());
        }

        private void Delete()
        {
            throw new NotImplementedException();
        }

        private void Update()
        {
            throw new NotImplementedException();
        }

        async void ReadAll()
        {
            var result = await client.GetContactsAsync();
            ContactList.Clear();
            foreach (Contact contact in result)
            {
                ContactList.Add(contact);
            }
            IsBusy = false;
        }

        async void ReadOne(string id)
        {
            await client.GetContactAsync("api/contact/"+id);
        }

        async Task Insert()
        {
            Contact contact = new Contact()
            {
                Name = this.Name,
                LastName = this.LastName
            };
            await client.CreateContactAsync(contact);
        }
    }
}
