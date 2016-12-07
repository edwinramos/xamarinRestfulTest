using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using XamarinFormsMongoDB.Models.Entities;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace XamarinFormsMongoDB.Models.Services
{
    public class ServiceClient
    {
        private HttpClient client = new HttpClient();

        public ServiceClient()
        {
            client.BaseAddress = new Uri("https://angular2-theerm.c9users.io/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Contact> UpdateContactAsync(Contact contact)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/contact/{contact.Id}", contact);
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

        public async Task<Uri> CreateContactAsync(Contact Contact)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/contacts", Contact);
                response.EnsureSuccessStatusCode();

                // Return the URI of the created resource.
                return response.Headers.Location;
            }
            catch (System.TypeLoadException ex)
            {
                string ss = ex.Message;
            }
            return null;
        }

        public async Task<Contact> GetContactAsync(string path)
        {
            Contact Contact = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                Contact = await response.Content.ReadAsAsync<Contact>();
            }
            return Contact;
        }
        //public async Task RunAsync()
        //{
        //    // New code:
        //    client.BaseAddress = new Uri("https://xamarintictactoe.herokuapp.com/");
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //}

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
