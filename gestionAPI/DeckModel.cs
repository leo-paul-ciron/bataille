using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GestionApi
{
    /*
     Modele de deck de l'api
     */

    public class DeckModel
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("cards")]
        public List<CardModel> Cards { get; set; }

        [JsonProperty("deck_id")]
        public string DeckId { get; set; }

        [JsonProperty("remaining")]
        public int Remaining { get; set; }
        
        [JsonProperty("piles")]
        public Pile Piles { get; set; }
    }
}
