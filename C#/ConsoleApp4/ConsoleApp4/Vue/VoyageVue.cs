using ConsoleApp4.Controler;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Vue
{
    class VoyageVue
    {
        public VoyageVue()
        {

        }

        // Affiche les données d une personne stockée dans un objet "personne"

        public static void AfficherVoyage(Voyage recup)
        {

            string affichage = "Informations Dossier \r\n\t";
            if (recup.Id_voyage > -1) { affichage += "ID voyage: " + recup.Id_voyage + "\r\n\t"; }
            if (recup.DateAller > DateTime.ParseExact("01010001", "ddMMyyyy", CultureInfo.InvariantCulture)) { affichage += "Départ le " + recup.DateAller.ToString("dd / MM / yy") + " \r\n\t"; }
            if (recup.DateRetour > DateTime.ParseExact("01010001", "ddMMyyyy", CultureInfo.InvariantCulture)) { affichage += "Retour le " + recup.DateRetour.ToString("dd / MM / yy") + " \r\n\t"; }
            if (recup.PlaceDispo > -1) { affichage += "Place disponibles : " + recup.PlaceDispo + "  "; }

            if (!string.IsNullOrEmpty(recup.TarifTC)) { affichage += "Tarif tout compris = '" + recup.TarifTC + "' \r\n\t"; }


            if (recup.Id_destination > -1) { affichage += "ID destination : " + recup.Id_destination + "  "; }
            if (recup.Id_agence > -1) { affichage += "ID agence : " + recup.Id_agence + "  "; };

            OutilVue.Afficher(affichage);

        }
    }
}
