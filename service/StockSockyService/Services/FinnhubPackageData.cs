using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockSockyService.Services
{
    public class FinnhubPackageData
    {
        [JsonProperty("s")]
        public string Symbol { get; set; }

        [JsonProperty("p")]
        public double Price { get; set; }

        [JsonProperty("t")]
        public long Timestamp { get; set; }

        [JsonProperty("v")]
        public int Volume { get; set; }
    }
}
