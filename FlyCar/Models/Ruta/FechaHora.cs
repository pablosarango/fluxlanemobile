using System;
using Newtonsoft.Json;

namespace FlyCar.Models.Ruta
{
    public class FechaHora
    {

        [JsonProperty(PropertyName = "creacion")]
        public DateTime creacion { get; set; }

        [JsonProperty(PropertyName = "fecha_captura")]
        public DateTime fecha_captura { get; set; }

        [JsonProperty(PropertyName = "inicio_captura")]
        public string inicio_captura { get; set; }

        [JsonProperty(PropertyName = "fin_captura")]
        public string fin_captura { get; set; }
    }
}
