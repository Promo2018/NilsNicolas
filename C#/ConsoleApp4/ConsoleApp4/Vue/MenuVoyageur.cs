using ConsoleApp4.Controler;
using ConsoleApp4.Model;
using ConsoleApp4.Vue;
using System;
using System.Collections.Generic;

namespace ConsoleApp4.Vue
{
    //menu client fonctionnement similaire au menu principal
    class MenuVoyageur
    {
        public MenuVoyageur()
        {
            
            OutilVue.Sep(7);
            OutilVue.Afficher("\n\n*****Menu Voyageur*****");
            List<string> listmenuV = new List<string>() { "1", "2", "3", "4", "5", "6" };
            OutilVue.Sep(7, "***** ");
            OutilVue.Afficher("Que voulez-vous faire ? \n\t 1. Créer Nouveau Voyageur \n\t 2. Rechercher/Modifier un Voyageur \n\t 3. Recherche par mot clef \n\t 4. Afficher la liste de tout les voyageurs \n\t 5. retour au menu precedent \n\t 6. Fermer le Programme");
            string saisie = OutilVue.Demander();

            if (listmenuV.Contains(saisie))
            {
                
                switch (saisie)
                {
                    // creer un voyageur, eventuellement le modifier avant de l ajouter à la BDD

                    case "1":

                        Personne.Nvo();
                        break;

                    case "2":

                        Personne.RechMod();
                        break;

                    case "3":
                        OutilVue.Dev("Recherche de voyageurs par mot clef");
                        break;
                    case "4":

                        Personne.Tous();
                        break;
                    case "5":
                        break;

                    case "6":
                        OutilVue.Quitter();
                        break;

                    default:
                        OutilVue.Afficher("Erreur Menu1");
                        break;
                }

            }

            else
            {
                OutilVue.Afficher(" ### Entree Invalide; Veuillez Saisir \"1\", \"2\", \"3\", \"4\", \"5\" ou \"6\" comme indiqué dans le menu ###");
                OutilVue.Pause();
            }

        }
    }
}
