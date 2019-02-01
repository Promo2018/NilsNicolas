using ConsoleApp4.Vue;
using System.Collections.Generic;

namespace ConsoleApp4.Vue
{
    class MenuDossier
    {
        public MenuDossier()
        {
                OutilVue.Sep(7);
                OutilVue.Afficher("\n\n*****Menu Dossier*****");
                List<string> listmenuV = new List<string>() { "1", "2", "3", "4", "5", "6" };
                OutilVue.Sep(7, "***** ");
                OutilVue.Afficher("Que voulez-vous faire ? \n\t 1. Créer Nouveau Dossier \n\t 2. Rechercher/Modifier un Dossier \n\t 3. Suivi Dossier \n\t 4. Afficher tout les dossiers en cours \n\t 5. retour au menu precedent \n\t 6. Fermer le Programme");
                string saisie = OutilVue.Demander();

            if (listmenuV.Contains(saisie))
            {

                switch (saisie)
                {


                    case "1":

                        OutilVue.Dev("Creation de dossier");
                        break;

                    case "2":
                        OutilVue.Dev("Recherche / modification des dossiers");
                        break;

                    case "3":
                        MenuSuivi();
                        break;

                    case "4":
                        OutilVue.Dev("Affichage de tout les voyageurs");
                        break;

                    case "5":
                        break;

                    case "6":
                        OutilVue.Quitter();
                        break;

                    default:
                        OutilVue.Afficher("Erreur Menu Dossier");
                        break;
                }

            }

            else
            {
                OutilVue.Afficher(" ### Entree Invalide; Veuillez Saisir \"1\", \"2\", \"3\", \"4\", \"5\" ou \"6\" comme indiqué dans le menu ###");
                OutilVue.Pause();
            }
        }

        public void MenuSuivi()
        {
            bool sema = true;
            while (sema)
            {
                OutilVue.Sep(7);
                OutilVue.Afficher("\n\n*****Suivi des Dossiers*****");
                List<string> listmenuV = new List<string>() { "1", "2", "3" };
                OutilVue.Sep(7, "***** ");
                OutilVue.Afficher("Que voulez-vous faire ? \n\t 1. Gerer l'avancement d'un dossier \n\t 2. Annuler un Dossier \n\t 3. retour au menu precedent \n\t");
                string saisie = OutilVue.Demander();

                if (listmenuV.Contains(saisie))
                {

                    switch (saisie)
                    {
                        case "1":

                            OutilVue.Dev("Gerer l'avancement du dossier");
                            sema=OutilVue.Precedent("rester dans le suivi des dossiers");
                            break;

                        case "2":
                            OutilVue.Dev("Annuler un Dossier");
                            sema = OutilVue.Precedent("rester dans le suivi des dossiers");
                            break;

                        case "3":
                            sema = false;
                            break;
                    }

                }

                else
                {
                    OutilVue.Afficher(" ### Entree Invalide; Veuillez Saisir \"1\", \"2\" ou \"3\" comme indiqué dans le menu ###");
                    OutilVue.Pause();
                }
            }
        }
      
    }
}
