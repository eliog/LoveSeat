using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LoveSeat
{
    public class CouchView
    {
        public CouchView(string aMap = null, string aReduce = null)
        {
            Map = aMap;
            Reduce = aReduce;
        }

        [JsonProperty("map")]
        public string Map { get; set; }

        [JsonProperty("reduce")]
        public string Reduce { get; set; }
    }
}
