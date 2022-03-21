using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionApi;
using GestionDeroulement;
using Xunit;
namespace TestUnitaire
{
    public class TestGestionRegle
    {

        public static GestionRegle gestion = new GestionRegle();

        [Fact]
        public async Task TestRechercheMaxNbIndex1()
        {

            List<int> valeurCarte = new List<int>()
            {
                3,
                3,
                2
            };

            List<int> indexEgalite = gestion.RechercheMax(valeurCarte);

            int nbIndex = indexEgalite.Count;

            Assert.Equal(nbIndex, 2);

        }

        [Fact]
        public async Task TestRechercheMaxNbIndex2()
        {

            List<int> valeurCarte = new List<int>()
            {
                3,
                2,
                2
            };

            List<int> indexEgalite = gestion.RechercheMax(valeurCarte);

            int nbIndex = indexEgalite.Count;

            Assert.Equal(nbIndex, 1);

        }

        [Fact]
        public async Task TestRechercheMaxNbIndex3()
        {

            List<int> valeurCarte = new List<int>()
            {
                3,
                2,
                2
            };

            List<int> indexEgalite = gestion.RechercheMax(valeurCarte);

            int value = indexEgalite[0];

            Assert.Equal(value, 0);

        }

        [Fact]
        public async Task TestRechercheMaxNbIndex4()
        {

            List<int> valeurCarte = new List<int>()
            {
                3,
                2,
                3
            };

            List<int> indexEgalite = gestion.RechercheMax(valeurCarte);

            int value1 = indexEgalite[0];
            int value2 = indexEgalite[1];

            Assert.Equal(value1, 0);
            Assert.Equal(value2, 2);

        }
    }
}
