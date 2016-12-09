using DemoAzureOfflineSync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsMongoDB.Models.Entities;
using Xamarin.Forms;

namespace XamarinFormsMongoDB.ViewModels
{
    public class ContactDetailVM: ObservableBaseObject
    {
        private Command SaveCommand { get; set; }
        private Command DeleteCommand { get; set; }

        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public ContactDetailVM()
        {
            SaveCommand = new Command(()=>Save(Id));
            DeleteCommand = new Command(()=>Delete(Id));
        }

        private void Delete(string Id)
        {
            throw new NotImplementedException();
        }

        private void Save(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
