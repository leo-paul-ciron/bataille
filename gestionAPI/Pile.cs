using System.Collections.Generic;
using Newtonsoft.Json;

namespace GestionApi
{
    public class Pile
    {

        public List<CardModel> lesCartes { get; set; }
        public string name { get; set; }
        public int nombreCarte;
       

        public Pile(int nombreCarte, string name)
        {
            this.name = name;
            this.nombreCarte = nombreCarte;

        }

        public void AjoutCardOnPile(List<CardModel> carteGagne)
        {
            List<CardModel> NewPile = new List<CardModel>();

            foreach (var carte in carteGagne)
            {
                NewPile.Add(carte);
            }

            foreach (var carte in lesCartes)
            {
                NewPile.Add(carte);
            }

            lesCartes = NewPile;

            nombreCarte = lesCartes.Count;

        }

        public CardModel TirageCardOnPile()
        {
            CardModel uneCarte;

            int nbCarte = lesCartes.Count;
            if (nbCarte > 0)
            {
                uneCarte = lesCartes[nbCarte-1];
                lesCartes.Remove(lesCartes[nbCarte-1]);
                nombreCarte = lesCartes.Count;
            }
            else
            {
                uneCarte = null;
            }

            return uneCarte;

        }
    }
}