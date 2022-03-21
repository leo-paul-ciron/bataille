using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionDeroulement;

namespace GestionAfichage
{
    class Program
    {
       
        public static async Task Main(string[] args)
        {
            string nombreJoueurString;
            Console.WriteLine("Entrer le nombre de joueur:");
            nombreJoueurString =  Console.ReadLine();




            int nombreJoueur = int.Parse(nombreJoueurString);


            
            Partie unePartie = new Partie();

            List<string> LesJoueur = new List<string>();

            int compteur = 0;
            int nombreJoueurInList = LesJoueur.Count;
            bool stop = true;
            

            for (int idx = 0; idx < nombreJoueur; idx++)
            {
                do
                {
                    Console.WriteLine($"Entrer le nom du joueur {idx+1}");
                    string name = Console.ReadLine();

                    if (LesJoueur.Contains(name))
                    {
                        Console.WriteLine("Nom déjà utilisé dans la partie. Entrer un nouveau nom");
                        name = Console.ReadLine();
                    }
                    else
                    {
                        LesJoueur.Add(name);
                        stop = false;
                    }

                } while (stop);

                

            }


            Console.WriteLine(" Debut de la partie ");
            await unePartie.Deroulement(LesJoueur);
            Console.Read();
            
        }
        
    }
}
