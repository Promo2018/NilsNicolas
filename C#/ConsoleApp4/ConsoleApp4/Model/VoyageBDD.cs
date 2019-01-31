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

        public static void AjouterVoy(Voyage recup)
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


        }
    }
}
