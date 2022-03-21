using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using GestionApi;

namespace GestionDeroulement
{
    public class GestionRegle
    {
        public  NameValueCollection listCarte = new NameValueCollection()
        {
            { "2", "1" },
            { "3", "2" },
            { "4", "3" },
            { "5", "4" },
            { "6", "5" },
            { "7", "6" },
            { "8", "7" },
            { "9", "8" },
            { "10", "9" },
            { "JACK", "10" },
            { "QUEEN", "11" },
            { "KING", "12" },
            { "ACE", "13" }
        };




        public async Task<string> comparaisonCarte(List<CardModel> lesCartes,List<Joueur> lesJoueurs)
        {
            
            string retour = "";

            int sommeCarte = 0;

            CardModel uneCarte = null;  

            List<int> valeurCarte = new List<int>();

            List<Joueur> JoueurEgalite = new List<Joueur>();
            List<int> indexRemove = new List<int>();


            for (int idx = 0; idx < lesJoueurs.Count; idx++)
            {
                sommeCarte = sommeCarte + lesJoueurs[idx].cartes.nombreCarte;

                

                if (lesJoueurs[idx].cartes.nombreCarte == 0)
                {
                    indexRemove.Add(idx);
                }
                else
                {
                    retour = retour + $"nombre carte de {lesJoueurs[idx].name}: {lesJoueurs[idx].cartes.nombreCarte} {Environment.NewLine}";
                    uneCarte = lesJoueurs[idx].tirageCarte();
                    int value = Convert.ToInt32(listCarte[uneCarte.Value]);

                    valeurCarte.Add(value);

                    retour = retour + $"{lesJoueurs[idx].name}: carte = {uneCarte.Value} {uneCarte.Suit} {Environment.NewLine}";

                    lesCartes.Add(uneCarte);

                }
            }

            int diffIndex = 0;
            foreach (var remove in indexRemove )
            {
                lesJoueurs.Remove(lesJoueurs[remove-diffIndex]);
                diffIndex++;
            }

            List<int> indexJoueur = RechercheMax(valeurCarte);

            if (indexJoueur.Count > 1)
            {

                retour = retour + $"Egalite {Environment.NewLine}";

                for (int i = 0; i < indexJoueur.Count; i++)
                {

                    int index = indexJoueur[i];
                    if (lesJoueurs.Count > 2)
                    {
                        if (lesJoueurs[index].cartes.nombreCarte >= 2)
                        {
                            lesCartes.Add(lesJoueurs[index].tirageCarte());
                        }
                        else
                        {
                            for (int idx = 0; idx < lesJoueurs[index].cartes.nombreCarte; idx++)
                            {
                                uneCarte = lesJoueurs[index].tirageCarte();
                                lesCartes.Add(uneCarte);
                            }

                            indexJoueur.Remove(index);
                            lesJoueurs.Remove(lesJoueurs[index]);
                        }
                    }
                    else
                    {
                        if (lesJoueurs[index].cartes.nombreCarte >= 2)
                        {
                            lesCartes.Add(lesJoueurs[index].tirageCarte());
                        }
                        else
                        {

                            retour = retour + $"PAT {Environment.NewLine}";

                            retour = retour + $"{sommeCarte} {Environment.NewLine}";
                            return retour;
                        }
                    }

                }


                if (indexJoueur.Count > 1)
                {
                    foreach (var index in indexJoueur)
                    {
                        JoueurEgalite.Add(lesJoueurs[index]);
                    }

                    string resultat = await comparaisonCarte(lesCartes, JoueurEgalite);
                    retour = retour + resultat;
                }
                else
                {
                    lesJoueurs[indexJoueur[0]].recupCarte(lesCartes);
                    retour = retour + $"le gagnant est: { lesJoueurs[indexJoueur[0]].name} {Environment.NewLine}";

                }
            }
            else
            {
                lesJoueurs[indexJoueur[0]].recupCarte(lesCartes);

                retour = retour + $"le gagnant est: { lesJoueurs[indexJoueur[0]].name} {Environment.NewLine}";
            }


            retour = retour + $"{sommeCarte} {Environment.NewLine}";
            return retour;
        }

        public List<int> RechercheMax(List<int> valeurCarte)
        {

            List<int> retour = new List<int>();
            retour.Add(valeurCarte.Max());
            retour = valeurCarte.Select((s, i) => new { s, i })
                                .Where(t => t.s == retour[0])
                                .Select(t => t.i)
                                .ToList();
            return retour;
        }

        
    }
}

