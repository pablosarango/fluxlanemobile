using System;
using Newtonsoft.Json;

namespace FlyCar.Models.Ruta
{
    public class Referencia
    {
        public Referencia()
        {
        }

        [JsonProperty(PropertyName = "nombre")]
        public string nombre { get; set; }

        [JsonProperty(PropertyName = "lat")]
        public double lat { get; set; }

        [JsonProperty(PropertyName = "lng")]
        public double lng { get; set; }
    }
}
