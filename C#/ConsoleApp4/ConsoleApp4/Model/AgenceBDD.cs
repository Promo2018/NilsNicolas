using ConsoleApp4.Controler;
using ConsoleApp4.Vue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Model
{
    class AgenceBDD
    {
        public AgenceBDD()
        {

        }

        public static void AjouterDest(Agence recup)
        {
            try
            {
                AccesBase BDD = new AccesBase("localhost", "BoVoyageNN");
                BDD.ConnectBDD();
                BDD.Access("insert into Voyages (nomAgence) values ('" + recup.NomAgence + "');");
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
