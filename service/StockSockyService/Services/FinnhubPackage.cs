using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockSockyService.Services
{
    public class FinnhubPackage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("data")]
        public FinnhubPackageData[] Data { get; set; }
    }
}
