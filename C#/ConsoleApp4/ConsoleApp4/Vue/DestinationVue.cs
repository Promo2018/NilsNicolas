using ConsoleApp4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Vue
{
    class DestinationVue
    {
        public DestinationVue()
        {

        }

        public static void AfficherDestination(Destination recup)
        {
            string affichage = "Informations Dossier \r\n\t";
            if (recup.Id_destination > -1) { affichage += "ID destination: " + recup.Id_destination + "\r\n\t"; }
            if (!string.IsNullOrEmpty(recup.Continent)) { affichage += "Continent : '" + recup.Continent + "' \r\n\t"; }
            if (!string.IsNullOrEmpty(recup.Pays)) { affichage += " Pays : '" + recup.Pays + "' "; }
            if (!string.IsNullOrEmpty(recup.Region)) { affichage += "Region : '" + recup.Region + "' \r\n\t"; }
            if (!string.IsNullOrEmpty(recup.Descriptif)) { affichage += "Descriptif : '" + recup.Descriptif + "' \r\n\t"; }

            OutilVue.Afficher(affichage);

        }
    }
}
