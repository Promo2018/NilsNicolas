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
                BDD.Access("insert into Personnes (civ, nom, prenom, date_naissance, age, adresse, tel, email) values ('" + recup.Civ +
                    "','" + recup.Nom + "','" + recup.Prenom + "','" + recup.Datenaissance + "'," + recup.Age + ",'" + recup.Adresse + "','" + recup.Tel + "','" +
                    recup.Email + "');");
                BDD.DisconBDD();
                OutilVue.Afficher("Le Nouveau Voyageur a bien été enregistré");
            }
            catch (Exception erreur)
            {
                OutilVue.Afficher("### Erreur d'enregistrement dans la Base de Données ### : /n"+erreur);
            }


        }

        public static List<Personne>RechercherVoyageur(Personne voyageura)
        {

            string requete = "select * from Personnes where ";
            if (voyageura.Id_personne > -1) { requete += "ID_personne = " + voyageura.Id_personne + " and "; }
            if (!string.IsNullOrEmpty(voyageura.Civ)) { requete += "civ = '" + voyageura.Civ + "' and "; }
            if (!string.IsNullOrEmpty(voyageura.Nom)) { requete += "nom = '" + voyageura.Nom + "' and "; }
            if (!string.IsNullOrEmpty(voyageura.Prenom)) { requete += "prenom = '" + voyageura.Prenom + "' and "; }
            if (voyageura.Datenaissance > DateTime.ParseExact("01010001", "ddMMyyyy", CultureInfo.InvariantCulture)) { requete += "date_naissance = '" + voyageura.Datenaissance.ToString("dd / MM / yy") + "' and "; }
            if (voyageura.Age > -1) { requete += "ID_personne = " + voyageura.Age + " and "; }
            if (!string.IsNullOrEmpty(voyageura.Adresse)) { requete += "adresse = '" + voyageura.Adresse + "' and "; }
            if (!string.IsNullOrEmpty(voyageura.Tel)) { requete += "tel = " + voyageura.Tel + " and "; }
            if (!string.IsNullOrEmpty(voyageura.Email)) { requete += "email = '" + voyageura.Email + "' and "; }
            requete += " 1 = 1";

            List<Personne> maListe = new List<Personne>();
            try
            {
                AccesBase BDD = new AccesBase("localhost", "BoVoyageNN");
                BDD.ConnectBDD();
                DataSet ds = BDD.Selectpersonne(requete);
               
                Personne vide = new Personne();
                if (ds.Tables["Resultats"].Rows.Count > 0)
                {
                    foreach (DataRow ligne in ds.Tables["Resultats"].Rows)
                    {
                        Personne per = new Personne(Int32.Parse(ligne["ID_personne"].ToString()), ligne["civ"].ToString(), ligne["nom"].ToString(), ligne["prenom"].ToString(), Convert.ToDateTime(ligne["date_naissance"]), Int32.Parse(ligne["age"].ToString()), ligne["adresse"].ToString(), ligne["tel"].ToString(), ligne["email"].ToString());
                        maListe.Add(per);
                    }
                    foreach (Personne elem in maListe) { PersonneVue.AfficherVoyageur(elem); }

                    

                }
            }
            catch (Exception erreur)
            {
                OutilVue.Afficher("### Erreur de requete select dans la BDD ### : /n"+erreur);
            }

            return maListe;
        }

        public static void Update( Personne recup)
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
                OutilVue.Afficher("Modification du Voyageur ...");
                switch (choix)
                {
                    case "1":
                        BDD.Access("update Personnes set civ = '" + recup.Civ + "' where ID_personne = " + recup.Id_personne + ";");
                        break;
                    case "2":
                        BDD.Access("update Personnes set prenom = '" + recup.Prenom + "' where ID_personne = " + recup.Id_personne + ";");
                        break;
                    case "3":
                        BDD.Access("update Personnes set nom = '" + recup.Nom + "' where ID_personne = " + recup.Id_personne + ";");
                        break;
                    case "4":
                        BDD.Access("update Personnes set date_naissance = '" + recup.Datenaissance.ToString() + "' where ID_personne = " + recup.Id_personne + ";");
                        break;
                    case "5":
                        BDD.Access("update Personnes set adresse = '" + recup.Adresse + "' where ID_personne = " + recup.Id_personne + ";");
                        break;
                    case "6":
                        BDD.Access("update Personnes set tel = " + recup.Tel.ToString() + " where ID_personne = " + recup.Id_personne + ";");
                        break;
                    case "7":
                        BDD.Access("update Personnes set email = '" + recup.Email + "' where ID_personne = " + recup.Id_personne + ";");
                        break;

                    default:
                        OutilVue.Afficher("Erreur menu update");
                        break;
                }
                OutilVue.Afficher("Modification du voyageur transmise au serveur");

                sema2 = OutilVue.Precedent("modifier un autre donnée de cette personne");


            }
            while (sema2);
        }

    }

}
