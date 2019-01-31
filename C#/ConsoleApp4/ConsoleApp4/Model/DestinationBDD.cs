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

        public static void AjouterDest(Destination recup)
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


        }
    }
}
