using Newtonsoft.Json;

namespace XamarinFormsMongoDB.Models.Entities
{
    public class Contact
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", this.Name, this.LastName); }
        }
    }
}
