using System;
using Newtonsoft.Json;

namespace GestionApi
{

    /*
     Modele de carte de l'api
     */

    public class CardModel
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
        

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("suit")]
        public string Suit { get; set; }

        public override string ToString()
        {
            return $"test:{Value}";
        }
    }
}
