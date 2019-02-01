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

        public static void RechMod()
        {
            bool sema9 = true;
            DossierReservation doss2 = new DossierReservation();
            DossierReservation doss3 = new DossierReservation();
            DossierReservation dnul = new DossierReservation();
            Personne client = new Personne();
            // rechercher un dossier a partir de ID_dossier, Id, nom et/ou prenom du client
            while (sema9)
            {
                doss2.ReinitDossier();
                bool sema10 = true;
                while (sema10)
                {
                    sema10 = false;
                    List<DossierReservation> listeR = new List<DossierReservation>();
                    OutilVue.Afficher("Veuillez saisir les informations suivantes pour trouver le Dossier que vous souhaitez modifier : Numéro de dossier, Identifiant unique, Prenom et/ou Nom du client\n\n\t La saisie d'un champ doit être complète et exacte pour fonctionner. Mais pas Besoin de remplir tout les champs. Un champ peut rester vide. \n ");

                    Controle.CIdDoss(ref doss2);
                    Controle.CIdClient(ref doss2);
                    Controle.CPrenom2(ref client);
                    Controle.CNom2(ref client);
                    Controle.CDDN2(ref client);
                    if (doss2 == dnul)
                    {
                        OutilVue.Afficher("Aucun critère de selection appliqué"); sema10 = OutilVue.Precedent("recommencer");
                    }
                    // si le dossier est trouve dans la BDD l'affiche et la stocke dans un objet dossier
                    else
                    {
                        listeR = DossierReservationBDD.RechercherDossier(doss2);
                        if (listeR.Count == 0)
                        {
                            OutilVue.Afficher("Aucun resultat trouvé");

                        }
                        else
                        {
                            bool sema11 = OutilVue.Precedent("modifier (un de) ce(s) dossier(s)");
                            if (sema11)
                            {

                                doss3.ReinitDossier();
                                switch (listeR.Count)
                                {
                                    case 1:
                                        doss3 = listeR[0];
                                        break;

                                    //si la methode rechercher retourne plusieurs resultats, il faut selectionner un des des dossiers retourné qui est à nouveau recuperé via son ID
                                    case int n when n > 1:
                                        OutilVue.Afficher(listeR.Count + " resultats trouvés. Selectionnez l'identifiant unique du dossier à modifier");
                                        List<int> ids = new List<int>();
                                        foreach (DossierReservation d in listeR)
                                        {
                                            ids.Add(d.Id_dossier);
                                        }

                                        bool sema12 = true;
                                        while (sema12)
                                        {
                                            Controle.CIdDoss(ref doss3);
                                            if (ids.Contains(doss3.Id_dossier))
                                            {
                                                List<DossierReservation> listeS = DossierReservationBDD.RechercherDossier(doss3);
                                                doss3 = listeS[0];
                                                sema12 = false;
                                            }
                                            else
                                            {
                                                OutilVue.Afficher("### Entrez l'identifiants de l'un des resultats de la recherche svp ###");
                                            }
                                        }

                                        break;

                                    default:
                                        OutilVue.Afficher("Erreur switch du menu modifier dossier");
                                        break;
                                }
                                // une fois qu on a isolé et "uploadé" la personne on la modifie
                                DossierReservationBDD.Update(doss3);


                            }

                            else
                            {
                                // OutilVue.Afficher("### Abbandon de la modification d'un Dossier ###");
                            }

                        }

                    }

                }
                sema9 = OutilVue.Precedent("continuer de rechercher/modifier des Dossiers");
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


    }
}
