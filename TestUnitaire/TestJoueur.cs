using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionApi;
using GestionDeroulement;
using Xunit;

namespace TestUnitaire
{
    public class TestJoueur
    {

        public static GestionCarte gestion = new GestionCarte();

        

        [Fact]
        public async Task TestRecupCarte()
        {
            
            DeckModel unDeck = new DeckModel();
            unDeck = await gestion.creationDeckAsync();

            List<string> name = new List<string>() {
                "leopaul",
                "arthur"
               };

            List<Pile> Piles = gestion.RemplissagePile(unDeck, name);

            Joueur leopaul = new Joueur("leopaul", Piles[0]);

            List<CardModel> lesCarte = new List<CardModel>();

            CardModel uneCarte = Piles[1].TirageCardOnPile();

            lesCarte.Add(uneCarte);

            leopaul.recupCarte(lesCarte);

            int nbCarte = leopaul.cartes.nombreCarte;

            Assert.Equal(nbCarte, 27);

        }


        [Fact]
        public async Task TestTirageCarte()
        {

            DeckModel unDeck = new DeckModel();
            unDeck = await gestion.creationDeckAsync();

            List<string> name = new List<string>() {
                "leopaul",
                "arthur"
               };

            List<Pile> Piles = gestion.RemplissagePile(unDeck, name);

            Joueur leopaul = new Joueur("leopaul", Piles[0]);

            CardModel uneCarte =  leopaul.tirageCarte();

            int nbCarte = leopaul.cartes.nombreCarte;

            Assert.Equal(nbCarte, 25);

        }

    }
}
