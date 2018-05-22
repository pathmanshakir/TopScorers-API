using System.Collections.Generic;
using Newtonsoft.Json;

namespace Model
{
    public class Coach
    {
        public int id { get; set; }
        public string foto { get; set; }
        public string fullName { get; set; }

        public string nationality { get; set; }
        [JsonIgnore]  
        public ICollection<Topscorer> player { get; set; }

    }
}