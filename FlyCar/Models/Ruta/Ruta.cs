using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FlyCar.Models.Ruta
{
    public class Ruta
    {
        [JsonProperty(PropertyName = "fecha_hora")]
        public FechaHora fecha_hora { get; set; }

        [JsonProperty(PropertyName = "estado")]
        public string estado { get; set; }

        [JsonProperty(PropertyName = "referencias")]
        public List<Referencia> referencias { get; set; }

        [JsonProperty(PropertyName = "subpuntos")]
        public List<object> subpuntos { get; set; }

        [JsonProperty(PropertyName = "_id")]
        public string _id { get; set; }

        [JsonProperty(PropertyName = "nombre")]
        public string nombre { get; set; }

        [JsonProperty(PropertyName = "descripcion")]
        public string descripcion { get; set; }

        [JsonProperty(PropertyName = "conductor_id")]
        public string conductor_id { get; set; }

        [JsonProperty(PropertyName = "velocidad_promedio")]
        public string velocidad_promedio { get; set; }

        [JsonProperty(PropertyName = "clima")]
        public string clima { get; set; }

        [JsonProperty(PropertyName = "int_captura")]
        public int int_captura { get; set; }
    }
}
