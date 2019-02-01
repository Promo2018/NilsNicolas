using System;
using ConsoleApp4.Controler;
using ConsoleApp4.Model;
using ConsoleApp4.Vue;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace ConsoleApp4.Model
{
    class VoyageBDD
    {
        public VoyageBDD()
        {

        }

        public static List<Voyage> RechercherVoyage(DossierReservation recup)
        {
            string requete = "select * from Voyages V, Dossiers D where V.ID_voyage = D.ID_voyage and D.ID_dossier = " + recup.Id_dossier + ";";

            List<Voyage> voyage1 = new List<Voyage>();
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
                        Voyage per = new Voyage(Int32.Parse(ligne["ID_voyage"].ToString()), Convert.ToDateTime(ligne["dateAller"].ToString()), Convert.ToDateTime(ligne["dateRetour"].ToString()), Int32.Parse(ligne["placeDispo"].ToString()), ligne["tarifToutCompris"].ToString(), Int32.Parse(ligne["ID_destination"].ToString()), Int32.Parse(ligne["ID_agence"].ToString()));
                        voyage1.Add(per);
                    }
                    foreach (Voyage elem in voyage1) { VoyageVue.AfficherVoyage(elem); }
                    OutilVue.Afficher("Resultat de la Requete : " + i + " correspondance(s) trouvées");

                }
            }
            catch (Exception erreur)
            {
                OutilVue.Afficher("### Erreur de requete select dans la BDD ### : /n" + erreur);
            }

            return voyage1;
        }

        /*public static void AjouterVoy(Voyage recup)
        {
            try
            {
                AccesBase BDD = new AccesBase("localhost", "BoVoyageNN");
                BDD.ConnectBDD();
                BDD.Access("insert into Voyages (dateAller, dateRetour, placeDispo, tarifToutCompris, ID_destination,ID_agence) values ('" + recup.DateAller +
                    "','" + recup.DateRetour + "'," + recup.PlaceDispo + ",'" + recup.TarifTC + "'," + recup.Id_destination + "," + recup.Id_agence + ");");
                BDD.DisconBDD();
                OutilVue.Afficher("Le Nouveau Voyageur a bien été enregistré");
            }
            catch (Exception erreur)
            {
                OutilVue.Afficher("### Erreur d'enregistrement dans la Base de Données ### : /n" + erreur);
            }


        }*/
    }
}
