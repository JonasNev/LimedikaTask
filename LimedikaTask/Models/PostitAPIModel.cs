using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimedikaTask.Models
{
    public class PostitAPIModel
    {

        public class Rootobject
        {
            [JsonProperty("status")]
            public string ?status { get; set; }
            [JsonProperty("sucess")]
            public bool ?success { get; set; }
            [JsonProperty("message")]
            public string ?message { get; set; }
            [JsonProperty("message_code")]
            public int ?message_code { get; set; }
            [JsonProperty("total")]
            public int ?total { get; set; }
            [JsonProperty("data")]
            public List<Data> ?data { get; set; }
        }

        public class Data
        {
            [JsonProperty("post_code")]
            public string ?post_code { get; set; }
            [JsonProperty("address")]
            public string ?address { get; set; }
            [JsonProperty("street")]
            public string ?street { get; set; }
            [JsonProperty("number")]
            public string? number { get; set; }
            [JsonProperty("only_number")]
            public string ?only_number { get; set; }
            [JsonProperty("housing")]
            public string ?housing { get; set; }
            [JsonProperty("city")]
            public string ?city { get; set; }
            [JsonProperty("municipality")]
            public string ?municipality { get; set; }
            [JsonProperty("post")]
            public string ?post { get; set; }
            [JsonProperty("mailbox")]
            public string ?mailbox { get; set; }
        }

    }
}
