using ConsoleApp4.Vue;
using ConsoleApp4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Controler
{
    class DossierReservation
    {
        public DossierReservation()
        {
            Id_dossier = -1;
            NumCB = null;
            EtatDossier1 = enAttente;
            RaisonAnnul = aucun;
            Id_voyage = -1;
            Id_client = -1;
        }

        public DossierReservation(int id_dossier, string numCB, string etatDossier, string raisonAnnul, int id_voyage, int id_client)
        {
            Id_dossier = id_dossier;
            NumCB = numCB;
            EtatDossier1 = enAttente;
            RaisonAnnul = aucun;
            Id_voyage = id_voyage;
            Id_client = id_client;
        }


        private int id_dossier;
        private string numCB;
        private int id_voyage;
        private int id_client;
        private string etatDossier;
        private string raisonAnnul;
        private string enAttente = EtatDossier.enAttente.ToString();
        private string enCours = EtatDossier.enCours.ToString();
        private string refusee = EtatDossier.refusee.ToString();
        private string acceptee = EtatDossier.acceptee.ToString();
        private string aucun = RaisonAnnulDossier.aucun.ToString();
        private string client = RaisonAnnulDossier.client.ToString();
        private string placesinsufisantes = RaisonAnnulDossier.placesinsufisantes.ToString();



        public int Id_dossier { get => id_dossier; set => id_dossier = value; }
        public string NumCB { get => numCB; set => numCB = value; }
        public int Id_voyage { get => id_voyage; set => id_voyage = value; }
        public int Id_client { get => id_client; set => id_client = value; }
        public string EnAttente { get => enAttente; set => enAttente = value; }
        public string EnCours { get => enCours; set => enCours = value; }
        public string Refusee { get => refusee; set => refusee = value; }
        public string Acceptee { get => acceptee; set => acceptee = value; }
        public string Aucun { get => aucun; set => aucun = value; }
        public string Client { get => client; set => client = value; }
        public string Placesinsufisantes { get => placesinsufisantes; set => placesinsufisantes = value; }
        public string EtatDossier1 { get => etatDossier; set => etatDossier = value; }
        public string RaisonAnnul { get => raisonAnnul; set => raisonAnnul = value; }

        enum EtatDossier
        {
            enAttente = 0,
            enCours = 1,
            refusee = 2,
            acceptee = 3,
        }

        enum RaisonAnnulDossier
        {
            aucun = 0,
            client = 1,
            placesinsufisantes = 2,
        }

        public void ReinitDossier()
        {
            Id_dossier = -1;
            NumCB = null;
            EtatDossier1 = enAttente;
            RaisonAnnul = aucun;
            Id_voyage = -1;
            Id_client = -1;
        }


        // cherche un dossier dans la BDD puis propose de le modifier et enregistre les modifications
        public static void RechModDoss()
        {
            bool sema9 = true;


            DossierReservation dnul = new DossierReservation();
            // rechercher le dossier a partir de ID, nom, prenom et/ou date de naissance
            while (sema9)
            {
                DossierReservation dossier3 = RecupDoss("modifier");
                if (dossier3.Id_dossier == -1)
                {
                    OutilVue.Afficher("Fin de la recherche/modification.");

                }
                else
                {
                    DossierReservationBDD.UpdateDoss(dossier3);

                }
                sema9 = OutilVue.Precedent("continuer de rechercher/modifier des Voyageurs");
            }
        }

        // cree un objet Dossier, demande a l'utilisateur de setter ses attributs settables, offre la possibilité de modifier cet objet puis l'enregistrer dans la BDD
        public static void Nvo()
        {
            //cree un objet Dossier
            DossierReservation dossier1 = new DossierReservation();
            bool sema2 = true;
            bool sema4 = true;
            while (sema2 == true)
            {
                //set ses attributs
                dossier1.ReinitDossier();
                dossier1 = DossierReservationVue.CreerDossier();


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
                            //modifier l'objet 
                            //DossierReservationVue.Modifier(ref dossier1);

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
                    //insert BDD
                    DossierReservationBDD.AjouterDossier(dossier1);
                    //verifier que l'insert a marché via la recherche
                    DossierReservationBDD.RechercherDossier(dossier1);
                    sema2 = OutilVue.Precedent("continuer d'ajouter des Dossiers");
                }
                else
                {
                    OutilVue.Afficher("### Abbandon de la création d'un Dossier ###");
                    sema2 = false;
                }

            }
        }

        // affiche la liste de tous les voyageurs
        public static void TousDossier()
        {
            DossierReservation dossier1 = new DossierReservation();
            dossier1.ReinitDossier();
            DossierReservationBDD.RechercherDossier(dossier1);
        }

        // recupere une personne a partir de son ID/nom/prenom et/ou ddn et la renvoie
        public static DossierReservation RecupDoss(string action)
        {
            
            DossierReservation dossier1 = new DossierReservation();
            DossierReservation dossier2 = new DossierReservation();
            DossierReservation dnul = new DossierReservation();
            Personne client = new Personne();
            // rechercher le dossier a partir de ID, nom, prenom et/ou date de naissance
            dossier1.ReinitDossier();
            bool sema10 = true;
            while (sema10)
            {
                sema10 = false;
                List<DossierReservation> listeR = new List<DossierReservation>();
                OutilVue.Afficher("Veuillez saisir les informations suivantes pour trouver le Voyageur que vous souhaiter modifier : Identifiant Unique, Prenom, Nom et Date de Naissance \n\n\t La saisie d'un champ doit être complète et exacte pour fonctionner. Mais pas Besoin de remplir tout les champs. Un champ peut rester vide. \n ");

                Controle.CIdDoss(ref dossier1);
                Controle.CIdClient(ref dossier1);

                if (dossier1.Id_dossier == -1 && dossier1.Id_client == -1)
                {
                    client = Personne.RecupPersDoss("recupération des données clients lié au dossier ");
                    dossier1.Id_client = client.Id_personne;

                }             
                
                if (dossier1.Id_dossier == -1 && dossier1.Id_client == -1 && client.Prenom == null && client.Nom == null)
                {
                    OutilVue.Afficher("Aucun critère de selection appliqué"); sema10 = OutilVue.Precedent("recommencer la saisie des critères de recherche");
                }
                // si la personne est trouvee dans la BDD l'affiche et la stoque dans un objet personne
                else
                {
                    listeR = DossierReservationBDD.RechercherDossier(dossier1);
                    if (listeR.Count == 0)
                    {
                        OutilVue.Afficher("Aucun resultat trouvé");

                    }
                    else
                    {
                        bool sema11 = OutilVue.Precedent(action + " (un de) ce(s) dossier");
                        if (sema11)
                        {

                            dossier2.ReinitDossier();
                            switch (listeR.Count)
                            {
                                case 1:
                                    dossier2 = listeR[0];
                                    break;

                                //si la methode rechercher retourne plusieurs resultat il faut selectionner un des dossiers retourné qui est à nouveau recuperéevia son ID
                                case int n when n > 1:
                                    OutilVue.Afficher(listeR.Count + " resultats trouvés. Selectionnez l'identifiant unique du voyageur à modifier");
                                    List<int> ids = new List<int>();
                                    foreach (DossierReservation p in listeR)
                                    {
                                        ids.Add(p.Id_dossier);
                                    }

                                    bool sema12 = true;
                                    while (sema12)
                                    {
                                        Controle.CIdDoss(ref dossier2);
                                        if (ids.Contains(dossier2.Id_dossier))
                                        {
                                            List<DossierReservation> listeS = DossierReservationBDD.RechercherDossier(dossier2);
                                            dossier2 = listeS[0];
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

                        }

                        else
                        {
                            sema11 = false;
                            // OutilVue.Afficher("### Abandon de la modification d'un Voyageur ###");
                        }

                    }

                }


            }
            return dossier2;
        }


    }
}
