using System;
using ConsoleApp4.Controler;
using ConsoleApp4.Model;
using ConsoleApp4.Vue;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace ConsoleApp4.Model
{
    class DestinationBDD
    {
        public DestinationBDD()
        {

        }


        public static List<Destination> RechercherDestination(Voyage recup)
        {
            string requete = "select * from Destination D, Voyages D where V.ID_destination = D.ID_destination and D.ID_voyage = " + recup.Id_voyage + ";";

            List<Destination> dest = new List<Destination>();
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
                        Destination d = new Destination(Int32.Parse(ligne["ID_destination"].ToString()), ligne["continent"].ToString(), ligne["pays"].ToString(), ligne["region"].ToString(), ligne["descriptif"].ToString());
                        dest.Add(d);
                    }
                    foreach (Destination elem in dest) { DestinationVue.AfficherDestination(elem); }
                    OutilVue.Afficher("Resultat de la Requete : " + i + " correspondance(s) trouvées");

                }
            }
            catch (Exception erreur)
            {
                OutilVue.Afficher("### Erreur de requete select dans la BDD ### : /n" + erreur);
            }

            return dest;
        }




        /*public static void AjouterDest(Destination recup)
        {
            try
            {
                AccesBase BDD = new AccesBase("localhost", "BoVoyageNN");
                BDD.ConnectBDD();
                BDD.Access("insert into Voyages (continent, pays, region, descriptif) values ('" + recup.Continent +
                    "','" + recup.Pays + "','" + recup.Region + "','" + recup.Descriptif + "');");
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
