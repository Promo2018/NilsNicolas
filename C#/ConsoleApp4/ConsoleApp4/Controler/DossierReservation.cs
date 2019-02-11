using ConsoleApp4.Vue;
using ConsoleApp4.Model;
using System.Collections.Generic;

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
            Personne client = new Personne();

            
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
                    //modif client
                    bool sema1 = OutilVue.Precedent("afficher/modifier le client lié à ce dossier");
                    if (sema1)
                    {
                        client.Reinit();client.Id_personne = dossier3.Id_client; PersonneBDD.RechercherVoyageur(client);
                        bool sema2 = OutilVue.Precedent("Modifier le client lié à ce dossier");
                        if (sema2)
                        {
                            DossierReservation.SetClient(ref dossier3);
                            DossierReservationBDD.UpdateDoss(dossier3, "3");
                        }
                        else
                        { }

                    }
                    //modif CB
                    sema1 = OutilVue.Precedent("afficher/modifier la carte bancaire liée à ce dossier");
                    if (sema1)
                    {
                        OutilVue.Afficher(dossier3.NumCB);
                        bool sema2 = OutilVue.Precedent("Modifier le numero de CB lié à ce dossier");
                        if (sema2)
                        { Controle.CCB(ref dossier3); DossierReservationBDD.UpdateDoss(dossier3, "1"); }
                        else
                        { }
                    }

                    // modif voyage
                    sema1 = OutilVue.Precedent("afficher/modifier le voyage lié à ce dossier");
                    if (sema1)
                    {
                        VoyageBDD.RechercherVoyage(dossier3);
                        DossierReservation.SetVoyage(ref dossier3);
                        DossierReservationBDD.UpdateDoss(dossier3, "2");
                    }

                    // modif liste participants
                    sema1 = OutilVue.Precedent("afficher/modifier la liste des particpants de ce dossier");
                    if (sema1)
                    {
                        //DEV !!!!
                        OutilVue.Dev("Afficher/modifier le(s) participant(s) de ce dossier");
                    }

                    // modif assurance

                    sema1 = OutilVue.Precedent("afficher/modifier la/les assurances de ce dossier");
                     if (sema1)
                    {
                        //DEV !!!!
                        OutilVue.Dev("Afficher/modifier la/les Assurance(s) de ce dossier");
                    }

                }
                sema9 = OutilVue.Precedent("continuer de rechercher/modifier des Dossiers");
            }
        }

        // cree un objet Dossier, demande a l'utilisateur de setter ses attributs settables, offre la possibilité de modifier cet objet puis l'enregistrer dans la BDD
        public static void NvoDossier()
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
                            DossierReservationVue.ModifierDoss(ref dossier1);

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




        // affiche la liste de tous les dossiers
        public static void TousDossier()
        {
            DossierReservation dossier1 = new DossierReservation();
            dossier1.ReinitDossier();
            DossierReservationBDD.RechercherDossier(dossier1);
        }

        // recupere un dossier a partir de son ID ou son client(ID/nom/prenom) et la renvoie
        public static DossierReservation RecupDoss(string action)
        {

            DossierReservation dossier1 = new DossierReservation();
            DossierReservation dossier2 = new DossierReservation();
            Personne client = new Personne();
            // rechercher le dossier a partir de ID dossier, ID client,  (nom, prenom et/ou date de naissance)client
            dossier1.ReinitDossier();
            bool sema10 = true;
            while (sema10)
            {
                sema10 = false;
                List<DossierReservation> listeR = new List<DossierReservation>();
                OutilVue.Afficher("Veuillez saisir les informations suivantes pour trouver le Dossier que vous souhaitez consulter/modifier : numéro de dossier ou informations client : Identifiant Unique Client ou son Prenom et son Nom \n\n\t La saisie d'un champ doit être complète et exacte pour fonctionner. Mais pas Besoin de remplir tout les champs. Un champ peut rester vide. \n ");

                Controle.CIdDoss2(ref dossier1);

                if (dossier1.Id_dossier == -1)
                {
                    client = Personne.RecupPersDoss("selectionner");
                    dossier1.Id_client = client.Id_personne;

                }

                if (dossier1.Id_dossier == -1 && dossier1.Id_client == -1)
                {
                    OutilVue.Afficher("Aucun critère de selection appliqué"); sema10 = OutilVue.Precedent("recommencer la saisie des critères de recherche");
                }
                // si la personne est trouvee dans la BDD l'affiche et la stoque dans un objet personne
                else
                {
                    listeR = DossierReservationBDD.RechercherDossier(dossier1);
                    if (listeR.Count == 0)
                    {
                        OutilVue.Afficher("Aucun Dossier trouvé");

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

                                //si la methode rechercher retourne plusieurs resultat il faut selectionner un des dossiers retourné qui est à nouveau recuperée via son ID
                                case int n when n > 1:
                                    OutilVue.Afficher(listeR.Count + " resultats trouvés. Selectionnez le numero du dossier à modifier");
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
                                            OutilVue.Afficher("### Entrez l'identifiant de l'un des resultats de la recherche svp ###");
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

        // impose de choisir un client pour un dossier
        public static void SetClient(ref DossierReservation dossierc)
        {

                
                bool sema = true;
                while (sema)
                {
                    Personne clientc = Personne.RecupPersDoss("selectionner");
                    if (clientc.Id_personne != -1)
                    {
                        sema = false;

                        //email client si la personne n est pas encore un client
                        while (clientc.Email == null)
                        {
                            OutilVue.Afficher("Un client doit avoir une adresse e-mail. Merci de mettre à jour ce champ pour cette personne");
                            PersonneBDD.Update(clientc, "7");
                            List<Personne> clientcs = PersonneBDD.RechercherVoyageur(clientc);
                            clientc = clientcs[0];
                        }

                        dossierc.Id_client = clientc.Id_personne;

                    }
                    else
                    {
                        OutilVue.Afficher("\n\t ###Vous devez selectionner un client pour créer un dossier.###\n\t");
                    
                    }
                }
            
        }

        //impose de choisir une ID voyage et l'ajoute au dossier
        public static void SetVoyage(ref DossierReservation dossier)
        {
            bool sema2 = true;
            while (sema2)
            {
                OutilVue.Afficher("ID Voyage :");
                Controle.CIdVoy(ref dossier);
                List<Voyage> Voyages = VoyageBDD.RechercherVoyage(dossier);
                sema2 = !OutilVue.Precedent("selectionner ce voyage");
            }
        }
    }
}
