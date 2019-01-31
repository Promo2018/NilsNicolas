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
            //PersonneBDD bddvoyageur = new PersonneBDD();
            PersonneVue affichagevoyageur = new PersonneVue();
            Personne voyageur1 = new Personne();
            OutilVue.Sep(7);
            OutilVue.Afficher("\n\n*****Menu Voyageur*****");
            List<string> listmenuV = new List<string>() { "1", "2", "3", "4", "5", "6" };
            OutilVue.Sep(7, "***** ");
            OutilVue.Afficher("Que voulez-vous faire ? \n\t 1. Créer Nouveau Voyageur \n\t 2. Rechercher/Modifier un Voyageur \n\t 3. Recherche par mot clef \n\t 4. Afficher la liste de tout les voyageurs \n\t 5. retour au menu precedent \n\t 6. Fermer le Programme");
            string saisie = OutilVue.Demander();

            if (listmenuV.Contains(saisie))
            {
                bool sema2 = true;
                bool sema4 = true;
                switch (saisie)
                {
                    // creer un voyageur, eventuellement le modifier avant de l ajouter à la BDD

                    case "1":
                        while (sema2 == true)
                        {
                            voyageur1 = PersonneVue.Creer();


                            bool sema3 = true;
                            while (sema3)
                            {
                                OutilVue.Afficher("Continuer et Sauvegarder ou Modifier ? \n\t 1. Continuer \n\t 2. Modifier \n\t 3. Abbandonner la Création \n\t");
                                string choix = OutilVue.Demander();
                                switch (choix)
                                {
                                    case "1":
                                        sema3 = false;
                                        break;

                                    case "2":
                                        PersonneVue.Modifier(ref voyageur1);

                                        break;
                                    case "3":
                                        sema4 = false;
                                        sema3 = false;
                                        break;

                                    default:
                                        OutilVue.Afficher("Entree Invalide; Veuillez Saisir \"1\" \"2\" ou \"3\" comme indiqué dans le menu ###");
                                        break;

                                }
                            }
                            if (sema4)
                            {
                                PersonneBDD.Ajouter(voyageur1);
                                PersonneBDD.RechercherVoyageur(voyageur1);
                                sema2 = OutilVue.Precedent("continuer d'ajouter des Voyageurs");
                            }
                            else
                            {
                                OutilVue.Afficher("### Abbandon de la création d'un Voyageur ###");
                                sema2 = false;
                            }

                        }

                        break;

                    case "2":

                        bool sema9 = true;
                        Personne voyageur2 = new Personne();
                        Personne voyageur3 = new Personne();
                        Personne vnul = new Personne();
                        while (sema9)
                        {
                            voyageur2.Reinit();
                            bool sema10 = true;
                            while (sema10)
                            {
                                sema10 = false;
                                List<Personne> listeR = new List<Personne>();
                                OutilVue.Afficher("Veuillez saisir les informations suivantes pour trouver le Voyageur que vous souhaiter modifier : Identifiant Unique, Prenom, Nom et Date de Naissance \n\n\t La saisie d'un champ doit être complète et exacte pour fonctionner. Mais pas Besoin de remplir tout les champs. Un champ peut rester vide. \n ");

                                Controle.CId2(ref voyageur2);
                                Controle.CPrenom2(ref voyageur2);
                                Controle.CNom2(ref voyageur2);
                                Controle.CDDN2(ref voyageur2);
                                if (voyageur2 == vnul)
                                {
                                    OutilVue.Afficher("Aucun critère de selection appliqué"); sema10 = OutilVue.Precedent("recommencer");
                                }
                                else
                                {
                                    listeR = PersonneBDD.RechercherVoyageur(voyageur2);
                                    if (listeR.Count == 0)
                                    {
                                        OutilVue.Afficher("Aucun resultat trouvé");

                                    }
                                    else
                                    {
                                        bool sema11 = OutilVue.Precedent("modifier (un de) ce(s) voyageur");
                                        if (sema11)
                                        {
                                            voyageur3.Reinit();
                                            switch (listeR.Count)
                                            {
                                                case 1:
                                                    voyageur3 = listeR[0];
                                                    break;

                                                case int n when n > 1:
                                                    OutilVue.Afficher(listeR.Count + " resultats trouvés. Selectionnez l'identifiant unique du voyageur à modifier");
                                                    List<int> ids = new List<int>();
                                                    foreach (Personne p in listeR)
                                                    {
                                                        ids.Add(p.Id_personne);
                                                    }
                                                    
                                                    bool sema12=true;
                                                    while (sema12)
                                                    {
                                                        Controle.CId(ref voyageur3);
                                                        if (ids.Contains(voyageur3.Id_personne))
                                                        {
                                                            List<Personne> listeS = PersonneBDD.RechercherVoyageur(voyageur3);
                                                            voyageur3 = listeS[0];
                                                            sema12 = false;
                                                        }
                                                        else
                                                        {
                                                            OutilVue.Afficher("### Entrez l'identifiants de l'un des resultats de la recherche svp ###");
                                                        }
                                                    }

                                                    break;

                                                default:
                                                    OutilVue.Afficher("Erreur switch du menu modifier voyageur");
                                                    break;
                                            }
                                            PersonneBDD.Update(voyageur3);
                                            

                                        }

                                        else
                                        {
                                           // OutilVue.Afficher("### Abbandon de la modification d'un Voyageur ###");
                                        }

                                    }
                                    
                                }
                               
                            }
                            sema9 = OutilVue.Precedent("continuer de rechercher/modifier des Voyageurs");
                        }
                        break;

                    case "3":
                        OutilVue.Dev("Recherche de voyageurs par mot clef");
                        break;
                    case "4":
                        PersonneBDD.RechercherVoyageur(voyageur1);
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
                OutilVue.Afficher(" ### Entree Invalide; Veuillez Saisir \"1\", \"2\", \"3\", \"4\", \"5\",ou \"6\" comme indiqué dans le menu ###");
                OutilVue.Pause();
            }

        }
    }
}
