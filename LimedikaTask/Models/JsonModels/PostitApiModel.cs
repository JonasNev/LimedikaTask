using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimedikaTask.Models.JsonModels
{
    public class PostitApiModel
    {
        public class Rootobject
        {
            public string? Status { get; set; }
            public bool? Success { get; set; }
            public string? Message { get; set; }
            public int? Message_code { get; set; }
            public int? Total { get; set; }
            public List<Data>? Data { get; set; }
        }

        public class Data
        {
            public string? Post_code { get; set; }
            public string? Address { get; set; }
            public string? Street { get; set; }
            public string? Number { get; set; }
            public string? Only_number { get; set; }
            public string? Housing { get; set; }
            public string? City { get; set; }
            public string? Municipality { get; set; }
            public string? Post { get; set; }
            public string? Mailbox { get; set; }
        }

    }
}
