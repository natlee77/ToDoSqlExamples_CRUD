using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo_Cosmos.Model
{

    public class ToDo
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "activity")]
        public string Activity { get; set; }
        [JsonProperty(PropertyName = "completed")]
        public bool Completed { get; set; }
        [JsonProperty(PropertyName = "creared")]
        public DateTime Created { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        
        public ToDo(string activity)
        {
            Id = Guid.NewGuid().ToString();
            Activity = activity;
            Completed = false;
            Created = DateTime.Now;

        }
    }
}
