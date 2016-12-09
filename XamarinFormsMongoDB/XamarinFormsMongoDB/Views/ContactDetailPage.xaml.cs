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
    public partial class ContactDetailPage : ContentPage
    {
        public ContactDetailPage(Contact contact)
        {
            InitializeComponent();
            BindingContext = new ContactDetailVM();
        }
    }
}
