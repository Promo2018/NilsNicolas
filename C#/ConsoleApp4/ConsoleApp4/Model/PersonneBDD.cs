using ConsoleApp4.Controler;
using ConsoleApp4.Model;
using ConsoleApp4.Vue;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace ConsoleApp4.Model
{
    class PersonneBDD
    {

        public PersonneBDD()
        {


        }

        // ##################################################
        // méthode pour ajouter dans la BDD en passant par la méthode Acces 
        public static void Ajouter(Personne recup)
        {
            try
            {
                AccesBase BDD = new AccesBase("localhost", "BoVoyageNN");
                BDD.ConnectBDD();
                string requete = "insert into Personnes (civ, nom, prenom, date_naissance, adresse, tel, email) values ('" + recup.Civ +
                    "','" + recup.Nom.Replace("'", "''") + "','" + recup.Prenom.Replace("'", "''") + "','" + recup.Datenaissance + "','" + recup.Adresse.Replace("'", "''") + "','" + recup.Tel + "','" +
                    recup.Email.Replace("'", "''") + "');";
                BDD.Access(requete);
                BDD.DisconBDD();
                OutilVue.Afficher("Le Nouveau Voyageur a bien été enregistré");
            }
            catch (Exception erreur)
            {
                OutilVue.Afficher("### Erreur d'enregistrement dans la Base de Données ### : /n"+erreur);
            }


        }

        // methode qui recherche un voyageur à partir des attributs d un objet objet voyageur et renvoie la liste des results trouvé sous forme d objets voyageur
        public static List<Personne>RechercherVoyageur(Personne voyageura)
        {


            string requete = "select * from Personnes where ";
            if (voyageura.Id_personne > -1) { requete += "ID_personne = " + voyageura.Id_personne + " and "; }
            if (!string.IsNullOrEmpty(voyageura.Civ)) { requete += "civ = '" + voyageura.Civ + "' and "; }
            if (!string.IsNullOrEmpty(voyageura.Nom)) { requete += "nom = '" + voyageura.Nom.Replace("'", "''") + "' and "; }
            if (!string.IsNullOrEmpty(voyageura.Prenom)) { requete += "prenom = '" + voyageura.Prenom.Replace("'", "''") + "' and "; }
            if (voyageura.Datenaissance > DateTime.ParseExact("01010001", "ddMMyyyy", CultureInfo.InvariantCulture)) { requete += "date_naissance = '" + voyageura.Datenaissance.ToString("dd/MM/yyyy") + "' and "; }
            if (!string.IsNullOrEmpty(voyageura.Adresse)) { requete += "adresse = '" + voyageura.Adresse.Replace("'", "''") + "' and "; }
            if (!string.IsNullOrEmpty(voyageura.Tel)) { requete += "tel = '" + voyageura.Tel + "' and "; }
            if (!string.IsNullOrEmpty(voyageura.Email)) { requete += "email = '" + voyageura.Email.Replace("'", "''") + "' and "; }
            requete += " 1 = 1;";

            List<Personne> maListe = new List<Personne>();
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
                        maListe.Add(per);
                    }
                    foreach (Personne elem in maListe) { PersonneVue.AfficherVoyageur(elem); }
                    OutilVue.Afficher("Resultat de la Requete : "+i+" correspondance(s) trouvées");

                    

                }
            }
            catch (Exception erreur)
            {
                OutilVue.Afficher("### Erreur de requete select dans la BDD ### : /n"+erreur);
            }

            return maListe;
        }

        //methode pour modifier un objet personne et updater ses modifs sur la BDD 

        public static void Update( Personne recup)
        {
            string choix;
            bool sema2;
            AccesBase BDD = new AccesBase("localhost", "BoVoyageNN");
            BDD.ConnectBDD();
            //modifier l'objet personne
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

                switch (choix)
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
                // requete d update
                OutilVue.Afficher("Modification du Voyageur ...");
                switch (choix)
                {
                    case "1":
                        BDD.Access("update Personnes set civ = '" + recup.Civ + "' where ID_personne = " + recup.Id_personne + ";");
                        break;
                    case "2":
                        BDD.Access("update Personnes set prenom = '" + recup.Prenom.Replace("'", "''") + "' where ID_personne = " + recup.Id_personne + ";");
                        break;
                    case "3":
                        BDD.Access("update Personnes set nom = '" + recup.Nom.Replace("'", "''") + "' where ID_personne = " + recup.Id_personne + ";");
                        break;
                    case "4":
                        BDD.Access("update Personnes set date_naissance = '" + recup.Datenaissance.ToString() + "' where ID_personne = " + recup.Id_personne + ";");
                        break;
                    case "5":
                        BDD.Access("update Personnes set adresse = '" + recup.Adresse.Replace("'", "''") + "' where ID_personne = " + recup.Id_personne + ";");
                        break;
                    case "6":
                        BDD.Access("update Personnes set tel = '" + recup.Tel + "' where ID_personne = " + recup.Id_personne + ";");
                        break;
                    case "7":
                        BDD.Access("update Personnes set email = '" + recup.Email.Replace("'", "''") + "' where ID_personne = " + recup.Id_personne + ";");
                        break;

                    default:
                        OutilVue.Afficher("Erreur menu update");
                        break;
                }
                OutilVue.Afficher("Modification du voyageur transmise au serveur");
                RechercherVoyageur(recup);
                sema2 = OutilVue.Precedent("modifier un autre donnée de cette personne");


            }
            while (sema2);
        }

        //meme methode mais pour MAJ un seul attribut prédéfini

        public static void Update(Personne recup, string numero)
        {
            List<string> listmenum = new List<string>() { "1", "2", "3", "4", "5", "6", "7" };
            string choix;
            bool sema2;
            AccesBase BDD = new AccesBase("localhost", "BoVoyageNN");
            BDD.ConnectBDD();
            //modifier l'objet personne
            do
            {

                
                do
                {

                    choix = numero;
                    if (!listmenum.Contains(choix))
                    {
                        OutilVue.Afficher("### Entree Invalide; Veuillez Saisir \"1\", \"2\", \"3\", \"4\", \"5\" , \"6\" ou \"7\" comme indiqué dans le menu ###");
                    }
                }
                while (!listmenum.Contains(choix));

                switch (choix)
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
                // requete d update
                OutilVue.Afficher("Modification du Voyageur ...");
                switch (choix)
                {
                    case "1":
                        BDD.Access("update Personnes set civ = '" + recup.Civ + "' where ID_personne = " + recup.Id_personne + ";");
                        break;
                    case "2":
                        BDD.Access("update Personnes set prenom = '" + recup.Prenom.Replace("'", "''") + "' where ID_personne = " + recup.Id_personne + ";");
                        break;
                    case "3":
                        BDD.Access("update Personnes set nom = '" + recup.Nom.Replace("'", "''") + "' where ID_personne = " + recup.Id_personne + ";");
                        break;
                    case "4":
                        BDD.Access("update Personnes set date_naissance = '" + recup.Datenaissance.ToString() + "' where ID_personne = " + recup.Id_personne + ";");
                        break;
                    case "5":
                        BDD.Access("update Personnes set adresse = '" + recup.Adresse.Replace("'", "''") + "' where ID_personne = " + recup.Id_personne + ";");
                        break;
                    case "6":
                        BDD.Access("update Personnes set tel = '" + recup.Tel + "' where ID_personne = " + recup.Id_personne + ";");
                        break;
                    case "7":
                        BDD.Access("update Personnes set email = '" + recup.Email.Replace("'", "''") + "' where ID_personne = " + recup.Id_personne + ";");
                        break;

                    default:
                        OutilVue.Afficher("Erreur menu update");
                        break;
                }
                OutilVue.Afficher("Modification du voyageur transmise au serveur");
                RechercherVoyageur(recup);
                sema2 = OutilVue.Precedent("modifier un autre donnée de cette personne");


            }
            while (sema2);
        }

    }

}
