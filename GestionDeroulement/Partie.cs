using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionApi;

namespace GestionDeroulement
{
    public  class Partie
    {

        public List<Joueur> participant;
        public DeckModel unDeck;

        GestionCarte gestionCarte = new GestionCarte() ;
        GestionRegle gestion = new GestionRegle();
        
        public async Task<List<Pile>> creationPile(List<string> nomJoueurs)
        {

            List<Pile> lesPiles = default;

            DeckModel LeDeck = new DeckModel();

            LeDeck = await gestionCarte.creationDeckAsync();

            int nombreJoueur = nomJoueurs.Count;

           
            lesPiles = gestionCarte.RemplissagePile(LeDeck,nomJoueurs);

            return lesPiles;
        }

        public async Task<int> creationJoueur(List<string> nomJoueurs)
        {
            participant = new List<Joueur>();

            List<Pile> lesPiles = await creationPile(nomJoueurs);

            int nombreJoueur = nomJoueurs.Count;
            
            for (int idx = 0; idx < nombreJoueur; idx++)
            {
               
                participant.Add(new Joueur(nomJoueurs[idx],lesPiles[idx]));
            }

           int nombreCarte =  participant[0].cartes.nombreCarte * nombreJoueur;

           return nombreCarte;
            
        }
        
        
        public async Task Deroulement(List<string> nomJoueurs)
        {
            
           int nombreCarteTotal =  await creationJoueur(nomJoueurs);
           
            Boolean Aucungagnant = true;
            string gagnantManche;
            int compteur = 1;
            string retour = null;
            string gagnant = null;

            do
            {

                List<CardModel> lesCarte = new List<CardModel>();
                
                Console.WriteLine($"manche {compteur}");
                compteur++;

                gagnantManche = await gestion.comparaisonCarte(lesCarte, participant);
                Console.WriteLine($"{gagnantManche}");
               
                foreach (Joueur joueur in participant)
                {
                    
                    if (joueur.cartes.nombreCarte==nombreCarteTotal || gagnantManche.Contains("PAT"))
                    {
                        
                        Aucungagnant = false;
                       gagnant = joueur.name;
                    }
                    
                }
                
            } while (Aucungagnant);

            retour = $"manche {compteur}" + ";" + $"{gagnantManche}";

            Console.WriteLine($"{retour}");

            if (gagnant != null)
            {
                Console.WriteLine($"{Environment.NewLine} {Environment.NewLine}le joueur {gagnant} à gagner la partie de bataille");

            }


        }

    }
}
