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

        public static void Update(DossierReservation recup)
        {
            string choix;
            bool sema2;
            AccesBase BDD = new AccesBase("localhost", "BoVoyageNN");
            BDD.ConnectBDD();

            do
            {

                List<string> listmenum = new List<string>() { "1", "2", "3", "4", "5", "6", "7" };
                do
                {
                    OutilVue.Afficher("\r\n Veuillez indiquer le champ que vous souhaitez modifier \r\n" +
                        "\n\t 1. Civilité  \n\t 2. Prénom  \n\t 3. Nom \n\t 4. Date de naissance \n\t 5. Adresse \n\t 6. Téléphone \n\t 7. e-mail \n\t");
                    choix = OutilVue.Demander();
                    if (!listmenum.Contains(choix))
                    {
                        OutilVue.Afficher("### Entree Invalide; Veuillez Saisir \"1\", \"2\", \"3\", \"4\", \"5\" , \"6\" ou \"7\" comme indiqué dans le menu ###");
                    }
                }
                while (!listmenum.Contains(choix));

                /* switch (choix)
                 {
                     case "1":
                         Controle.CCivilite(ref recup);

                         break;
                     case "2":
                         Controle.CPrenom(ref recup);
                         break;
                     case "3":
                         Controle.CNom(ref recup);
                         break;
                     case "4":
                         Controle.CDDN(ref recup);
                         break;
                     case "5":
                         Controle.CAdresse(ref recup);
                         break;
                     case "6":
                         Controle.CTel(ref recup);
                         break;
                     case "7":
                         Controle.CEmail(ref recup);
                         break;

                     default:
                         OutilVue.Afficher("Erreur menu modifier objet Personne");
                         break;
                 }
                 OutilVue.Afficher("Modification du Voyageur ...");*/
                switch (choix)
                {
                    case "1":
                        BDD.Access("update Dossiers set n_CB = '" + recup.NumCB + "' where ID_dossier = " + recup.Id_dossier + ";");
                        break;
                    case "2":
                        BDD.Access("update Dossiers set etatDossier = " + recup.EtatDossier1 + " where ID_dossier = " + recup.Id_dossier + ";");
                        break;
                    case "3":
                        BDD.Access("update Dossiers set raisonAnnulation = " + recup.RaisonAnnul + " where ID_dossier = " + recup.Id_dossier + ";");
                        break;
                    case "4":
                        BDD.Access("update Dossiers set ID_voyage = " + recup.Id_voyage + " where ID_dossier = " + recup.Id_dossier + ";");
                        break;
                    case "6":
                        BDD.Access("update Dossiers set ID_client = " + recup.Id_client + " where ID_dossier = " + recup.Id_dossier + ";");
                        break;

                    default:
                        OutilVue.Afficher("Erreur menu update");
                        break;
                }
                OutilVue.Afficher("Modification du voyageur transmise au serveur");
                RechercherDossier(recup);
                sema2 = OutilVue.Precedent("modifier un autre donnée de cette personne");


            }
            while (sema2);
        }
    }
}
