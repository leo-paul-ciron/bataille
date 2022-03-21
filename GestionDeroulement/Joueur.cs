using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionApi;

namespace GestionDeroulement
{
    public class Joueur
    {
        public string name { get; }
        public Pile cartes;
        public GestionCarte gestionCarte = new GestionCarte();

        public Joueur(string name)
        {
            this.name = name;
        }

        public Joueur(string name, Pile cartes)
        {
            this.name = name;
            this.cartes = cartes;
        }


        /*
            On tire une carte dans la pile du joueur

            On retourne une carte, la carte suis le model de CardModel
         */
        public CardModel tirageCarte()
        {
            CardModel uneCarte = default;
            uneCarte = cartes.TirageCardOnPile();
            
           return uneCarte;
        }


        /*
            On ajoute une carte dans la pile du joueur
         */
        public void recupCarte(List<CardModel> carteGagne)
        {
           cartes.AjoutCardOnPile(carteGagne);
        }

        public int NombreCartePile()
        {
            return cartes.nombreCarte;
        }
    }
}
