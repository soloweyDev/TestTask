using Newtonsoft.Json;
using System;

namespace TestTask
{
    public struct Person
    {
        [JsonProperty("Full Name")] public string FullName;
        public string Country;
        [JsonProperty("Created At")] public DateTime CreatedAt;
        public int Id;
        public string Email;
    }
}
