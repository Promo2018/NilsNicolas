using System;
using System.Collections.Generic;
using System.Data;
using ConsoleApp4.Controler;
using ConsoleApp4.Vue;

namespace ConsoleApp4.Model
{
    class DossierReservationBDD
    {
        public DossierReservationBDD()
        {

        }

        // ##################################################
        // méthode pour ajouter dans la BDD en passant par la méthode Acces 
        public static void AjouterDossier(DossierReservation recup)
        {
            try
            {
                AccesBase BDD = new AccesBase("localhost", "BoVoyageNN");
                BDD.ConnectBDD();
                BDD.Access("insert into Dossiers (n_CB, ID_voyage, ID_client) values ('" + recup.NumCB + "'," + recup.Id_voyage + "," + recup.Id_client + ");");
                BDD.DisconBDD();
                OutilVue.Afficher("Le Nouveau Voyageur a bien été enregistré");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //OutilVue.Afficher("### Erreur d'enregistrement dans la Base de Données ### : /n" + erreur);
            }

        }

        public static List<DossierReservation> RechercherDossier(DossierReservation recup)
        {
            string requete = "select * from Dossiers where ";
            if (recup.Id_dossier > -1) { requete += "ID_dossier = " + recup.Id_dossier + " and "; }
            if (!string.IsNullOrEmpty(recup.NumCB)) { requete += "n_CB = '" + recup.NumCB.Replace("'", "''") + "' and "; }
            if (recup.Id_voyage > -1) { requete += "ID_voyage = " + recup.Id_voyage + " and "; }
            if (recup.Id_client > -1) { requete += "ID_client = " + recup.Id_client + " and "; }
            requete += " 1 = 1;";

            List<DossierReservation> ListeDossier = new List<DossierReservation>();
            try
            {

                AccesBase BDD = new AccesBase("localhost", "BoVoyageNN");
                BDD.ConnectBDD();
                DataSet ds = BDD.Select(requete);

                if (ds.Tables["Resultats"].Rows.Count > 0)
                {
                    int i = 0;
                    foreach (DataRow ligne in ds.Tables["Resultats"].Rows)
                    {
                        i = i + 1;
                        DossierReservation doss = new DossierReservation(Int32.Parse(ligne["ID_dossier"].ToString()), ligne["n_CB"].ToString(), ligne["etatDossier"].ToString(), ligne["raisonAnnulation"].ToString(), Int32.Parse(ligne["ID_voyage"].ToString()), Int32.Parse(ligne["ID_client"].ToString()));
                        ListeDossier.Add(doss);

                    }
                    foreach (DossierReservation elem in ListeDossier) { DossierReservationVue.AfficherDossier(elem); }
                    OutilVue.Afficher("Resultat de la Requete : " + i + " correspondance(s) trouvées");

                }
            }
            catch (Exception erreur)
            {
                OutilVue.Afficher("### Erreur de requete select dans la BDD ### : /n" + erreur);
            }

            return ListeDossier;
        }


        public static List<Personne> RechercherClientDossier(DossierReservation recup)
        {
            string requete = "Select * from Personnes P, Dossiers D where P.ID_personne = D.ID_client and ID_dossier = " + recup.Id_dossier + ";";

            List<Personne> client = new List<Personne>();
            try
            {

                AccesBase BDD = new AccesBase("localhost", "BoVoyageNN");
                BDD.ConnectBDD();
                DataSet ds = BDD.Select(requete);

                if (ds.Tables["Resultats"].Rows.Count > 0)
                {
                    int i = 0;
                    foreach (DataRow ligne in ds.Tables["Resultats"].Rows)
                    {
                        i = i + 1;
                        Personne per = new Personne(Int32.Parse(ligne["ID_personne"].ToString()), ligne["civ"].ToString(), ligne["nom"].ToString(), ligne["prenom"].ToString(), Convert.ToDateTime(ligne["date_naissance"].ToString()), ligne["adresse"].ToString(), ligne["tel"].ToString(), ligne["email"].ToString(), Int32.Parse(ligne["client"].ToString()), Int32.Parse(ligne["participant"].ToString()), float.Parse(ligne["reduction"].ToString()));
                        client.Add(per);
                    }
                    foreach (Personne elem in client) { PersonneVue.AfficherVoyageur(elem); }
                    OutilVue.Afficher("Resultat de la Requete : " + i + " correspondance(s) trouvées");

                }
            }
            catch (Exception erreur)
            {
                OutilVue.Afficher("### Erreur de requete select dans la BDD ### : /n" + erreur);
            }

            return client;
        }


        public static List<Personne> ListeaParticpant(DossierReservation recup)
        {
            string requete = "Select P.nom, P.prenom, D.ID_dossier from Personnes P, Dossiers D, ParticipDoss Pd where D.ID_dossier = " + recup.Id_dossier + " " +
                "and P.ID_personne = Pd.ID_participant and Pd.ID_dossier = D.ID_dossier; ";


            List<Personne> client = new List<Personne>();
            try
            {
                AccesBase BDD = new AccesBase("localhost", "BoVoyageNN");
                BDD.ConnectBDD();
                DataSet ds = BDD.Select(requete);

                if (ds.Tables["Resultats"].Rows.Count > 0)
                {
                    int i = 0;
                    foreach (DataRow ligne in ds.Tables["Resultats"].Rows)
                    {
                        i = i + 1;
                        Personne per = new Personne(Int32.Parse(ligne["ID_personne"].ToString()), ligne["civ"].ToString(), ligne["nom"].ToString(), ligne["prenom"].ToString(), float.Parse(ligne["reduction"].ToString()));
                        client.Add(per);
                    }
                    foreach (Personne elem in client) { PersonneVue.AfficherVoyageur(elem); }
                    OutilVue.Afficher("Resultat de la Requete : " + i + " correspondance(s) trouvées");

                }
            }
            catch (Exception erreur)
            {
                OutilVue.Afficher("### Erreur de requete select dans la BDD ### : /n" + erreur);
            }

            return client;
        }



        public static void UpdateDoss(DossierReservation recup)
        {
            string choix;
            bool sema2;
            AccesBase BDD = new AccesBase("localhost", "BoVoyageNN");
            BDD.ConnectBDD();

            do
            {

                List<string> listmenum = new List<string>() { "1", "2", "3" };
                do
                {
                    OutilVue.Afficher("\r\n Veuillez indiquer le champ que vous souhaitez modifier \r\n" +
                        "\n\t 1. Numéro de carte bancaire  \n\t 2. ID  Voyage  \n\t 3. ID client");
                    choix = OutilVue.Demander();
                    if (!listmenum.Contains(choix))
                    {
                        OutilVue.Afficher("### Entree Invalide; Veuillez Saisir \"1\", \"2\" ou \"3\" comme indiqué dans le menu ###");
                    }
                }
                while (!listmenum.Contains(choix));

                switch (choix)
                 {
                     case "1":
                         Controle.CCB(ref recup);
                         break;
                     case "2":
                         Controle.CIdVoy(ref recup);
                         break;
                     case "3":
                         Controle.CIdClient(ref recup);
                         break;
                     

                     default:
                         OutilVue.Afficher("Erreur menu modifier objet Dossier");
                         break;
                 }
                 OutilVue.Afficher("Modification du dossier ...");
                switch (choix)
                {
                    case "1":
                        BDD.Access("update Dossiers set n_CB = '" + recup.NumCB + "' where ID_dossier = " + recup.Id_dossier + ";");
                        break;
                    case "2":
                        BDD.Access("update Dossiers set ID_voyage = " + recup.Id_voyage + " where ID_dossier = " + recup.Id_dossier + ";");
                        break;
                    case "3":
                        BDD.Access("update Dossiers set ID_client = " + recup.Id_client + " where ID_dossier = " + recup.Id_dossier + ";");
                        break;
                  

                    default:
                        OutilVue.Afficher("Erreur menu update");
                        break;
                }
                OutilVue.Afficher("Modification du dossier transmise au serveur");
                RechercherDossier(recup);
                sema2 = OutilVue.Precedent("modifier une autre donnée de ce dossier");


            }
            while (sema2);
        }
    }
}
