using System;
using Xunit;
using GestionApi;

using System.Threading.Tasks;
using System.Collections.Generic;

namespace TestUnitaire
{
    public class UnitTest1
    {

        public static GestionCarte gestion = new GestionCarte();

        [Fact]
        public async Task TestTirageCarteDeckAsync()
        {

            
            DeckModel unDeck = new DeckModel();
            unDeck = await gestion.creationDeckAsync();

            CardModel retour = gestion.TirageUneCarte(unDeck);

            Assert.NotEqual(retour, null);

        }

        [Fact]
        public async Task TestCreationDeck()
        {

            DeckModel unDeck = new DeckModel();
            unDeck = await gestion.creationDeckAsync();

          
            Assert.NotEqual(unDeck, null);

        }

        [Fact]
        public async Task TestRemplissagePile()
        {

            DeckModel unDeck = new DeckModel();
            unDeck = await gestion.creationDeckAsync();
            List<string> name = new List<string>() {
                "leopaul",
                "arthur"
               };

            List<Pile> Piles = gestion.RemplissagePile(unDeck, name);

            Assert.NotEqual(Piles, null);

        }

        [Fact]
        public async Task TestRemplissagePilenbPile()
        {

            DeckModel unDeck = new DeckModel();
            unDeck = await gestion.creationDeckAsync();
            List<string> name = new List<string>() {
                "leopaul",
                "arthur"
               };

            List<Pile> Piles = gestion.RemplissagePile(unDeck, name);
            int nbPile = Piles.Count;

            Assert.Equal(nbPile, 2 );

        }

        [Fact]
        public async Task TestRemplissagePileName()
        {

            DeckModel unDeck = new DeckModel();
            unDeck = await gestion.creationDeckAsync();
            List<string> name = new List<string>() {
                "leopaul",
                "arthur"
               };

            List<Pile> Piles = gestion.RemplissagePile(unDeck, name);
            string namePile = Piles[0].name;

            Assert.Equal(namePile, "leopaul");

        }



        
    }
}
