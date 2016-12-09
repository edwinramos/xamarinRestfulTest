using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using XamarinFormsMongoDB.Models.Entities;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text;

namespace XamarinFormsMongoDB.Models.Services
{
    public class ServiceClient
    {
        private HttpClient client = new HttpClient();

        public ServiceClient()
        {
            client.BaseAddress = new Uri("https://xamarintictactoe.herokuapp.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Contact> UpdateContactAsync(Contact contact)
        {
            var json = JsonConvert.SerializeObject(contact);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(client.BaseAddress + "api/contacts/" + contact.Id, content);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated Contact from the response body.
            contact = await response.Content.ReadAsAsync<Contact>();
            return contact;
        }

        public async Task<HttpStatusCode> DeleteContactAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/contact/{id}");
            return response.StatusCode;
        }

        public async Task<Uri> CreateContactAsync(Contact contact)
        {

            var json = JsonConvert.SerializeObject(contact);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(client.BaseAddress + "api/contacts", content);

            //HttpResponseMessage response = await client.PostAsJsonAsync("api/contacts", contact);
            response.EnsureSuccessStatusCode();

            // Return the URI of the created resource.
            return response.Headers.Location;
        }

        public async Task<Contact> GetContactAsync(string id)
        {
            Contact Contact = null;
            HttpResponseMessage response = await client.GetAsync(string.Format("{0}api/contact/{1}", client.BaseAddress, id));
            if (response.IsSuccessStatusCode)
            {
                Contact = await response.Content.ReadAsAsync<Contact>();
            }
            return Contact;
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync()
        {
            string response = await client.GetStringAsync(client.BaseAddress + "api/contacts");
            IEnumerable<Contact> contactList = JsonConvert.DeserializeObject<IEnumerable<Contact>>(response);
            return contactList;
        }

        //public string Serialize(IEnumerable<Contact> contacts)
        //{
        //    string json = JsonConvert.SerializeObject(contacts);
        //    Debug.WriteLine(json);

        //    return json;
        //}

        //public IEnumerable<Contact> Deserialize(string json)
        //{
        //    IEnumerable<Contact> parsedJson = JsonConvert.DeserializeObject<IEnumerable<Contact>>(json);
        //    //foreach (var item in parsedJson)
        //    //{
        //    //    Debug.WriteLine(item.Id);
        //    //}

        //    return parsedJson;
        //}
    }
}
