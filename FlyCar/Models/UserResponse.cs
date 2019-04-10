using System;
using Newtonsoft.Json;

namespace FlyCar.Models
{
    public class UserResponse
    {
        public UserResponse()
        {
        }

        #region Attributes
        [JsonProperty(PropertyName = "_id")]
        public string _id { get; set; }


        [JsonProperty(PropertyName = "token")]
        public string token;
        #endregion

    }
}
