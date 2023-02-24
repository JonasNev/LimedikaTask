using LimedikaTask.Models.JsonModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LimedikaTask.Services
{
    public class JsonReader : IJsonReader
    {
        string path = Path.Combine(Environment.CurrentDirectory, @"Files\Json\", "klientai.json");
        public List<JsonPharmacyModel.Pharmacy>? ReadJson()
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<JsonPharmacyModel.Pharmacy>>(json);
                return items;
            }
        }
    }
}
