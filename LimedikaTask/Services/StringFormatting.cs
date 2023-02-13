using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimedikaTask.Services
{
    public class StringFormatting
    {
        public string CreateQuery(string address, string key, string baseUrl)
        {
            var addressAndCity = address.Split(",");
            var adress = addressAndCity[0].Replace(" ", "+");
            var city = addressAndCity[1].Replace(" ", "");
            return $"{baseUrl}city={city}&address={adress}&key={key}";
        }
    }
}
