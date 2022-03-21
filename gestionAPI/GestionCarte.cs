using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GestionApi
{
    public  class GestionCarte
    {

        static readonly HttpClient client = new HttpClient();



        /*

        Methode de creation de deck par recuperation des valeurs grace a l'api
            
         */

        public async Task<DeckModel> creationDeckAsync()
        {
            
            HttpResponseMessage response;

            DeckModel unDeck = default;

            try
            {
                response = await
                    client.GetAsync("https://deckofcardsapi.com/api/deck/new/draw/?count=52");
                response.EnsureSuccessStatusCode();

                string DeckResponse = await response.Content.ReadAsStringAsync();

                unDeck = JsonConvert.DeserializeObject<DeckModel>(DeckResponse);

            }
            catch (HttpRequestException e)
            {
                //dois partir pour faire appel a l'affichage console 
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return unDeck;
        }


        /*
            Methode de tirage de carte dans un deck
         */
        public CardModel TirageUneCarte(DeckModel unDeck)
        {
            // On recupère la premiere carte du deck 
            CardModel uneCarte = unDeck.Cards[0];

            //on supprime la première carte du deck car déjà utilisé
            unDeck.Cards.RemoveAt(0);

            return uneCarte;
        }



        /*
         
            Méthode de création des piles des joueurs

            On retourne une liste de pile contenant le nombre de carte, le nom
            du joueur et une liste de carte
         
         */
        public List<Pile> RemplissagePile(DeckModel unDeck, List<string> joueurs)
        {
            
           
            List<Pile> lesPiles = new List<Pile>();
            int nombreJoueur = joueurs.Count;
            int nombreCarte = 0;
            
            foreach (string joueur in joueurs)
            {
                lesPiles.Add(new Pile(0,joueur));
                
            }

            foreach (var pile in lesPiles)
            {
                pile.lesCartes = new List<CardModel>();
            }

            int nombreCarteJoueur = unDeck.Cards.Count / nombreJoueur;

            for (int idx = 0; idx < nombreCarteJoueur; idx++)
            {
                nombreCarte++;
                for (int i = 0; i < nombreJoueur; i++)
                {
                    string unJoueur = joueurs[i];

                    CardModel uneCarte = TirageUneCarte(unDeck);

                    string codeCarte = uneCarte.Code;

                    lesPiles[i].lesCartes.Add(uneCarte);

                }
            }

            foreach (Pile pile in lesPiles)
            {
                pile.nombreCarte = nombreCarte;
            }

            return lesPiles;

        }
    }
}
