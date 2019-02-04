using System;
using System.Collections.Generic;
using ConsoleApp4.Controler;

namespace ConsoleApp4.Vue
{
    class MenuP
    {
        ~MenuP()

        //destructeur
        {
            OutilVue.Sep(6); OutilVue.Sep(6);
            OutilVue.Afficher("Fermeture du processus ...");
            OutilVue.Sep(6); OutilVue.Sep(6);
            OutilVue.Pause();

        }
        //constructeur
        public MenuP()
        {

            //semaphore de sortie de boucle menu principal
            bool sema1 = true;
            OutilVue.Afficher("\n\n*****Menu Principal*****");
            while (sema1)
            {
                //"menu principal"
                OutilVue.Sep(7, "***** ");
                
                // on cree un liste qui stocke les options du menu//
                List<string> listmenup = new List<string>() { "1", "2", "3" };
                OutilVue.Sep(7, "***** ");
                Console.WriteLine("A quel Menu voulez vous acceder? \n\t 1.Menu Client \n\t 2.Menu Voyage \n\t 3.Quitter?");
                //on stocke la saisie//
                string saisie = OutilVue.Demander();
                //boucle pour l erreur de saisie
                if (listmenup.Contains(saisie))
                {
                    bool sema2 = true;
                    switch (saisie)
                    {

                        case "1":
                     //acces au menu voyageurs
                            while (sema2)
                            {
                                MenuVoyageur surclient = new MenuVoyageur();
                                OutilVue.Afficher("*****Menu Voyageur*****");
                                sema2 = OutilVue.Precedent("continuer avec le menu voyageur");
                            }      
                            break;
                        case "2":
                            //acces au menu dossiers
                            while (sema2)
                            {
                                MenuDossier survoyage = new MenuDossier();
                                OutilVue.Afficher("*****Menu Principal*****");
                                sema2 = OutilVue.Precedent("continuer avec le menu dossier");
                            }
                            break;
                        case "3":
                            OutilVue.Quitter();
                            break;
                            
                        default:
                            OutilVue.Afficher("Erreur Menu1");
                            OutilVue.Pause();

                            break;
                    }

                }
                //en cas d erreur de saisie
                else
                {
                    OutilVue.Afficher("Entree Invalide; Veuillez Saisir \"1\", \"2\" ou \"3\" comme indiqué dans le menu");
                }
                OutilVue.Afficher("\n\n*****Menu Principal*****");
            }
            
            sema1 = OutilVue.Precedent("retourner au menu principal");
        }
    }
}
