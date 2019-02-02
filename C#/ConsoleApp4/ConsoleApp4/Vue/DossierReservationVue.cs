using ConsoleApp4.Controler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Vue
{
    class DossierReservationVue
    {
        public static DossierReservation CreerDossier()

        {
            DossierReservation dossier = new DossierReservation();
            OutilVue.Afficher("\n Pour ajouter un voyageur, veuillez renseigner les informations suivantes :");

            OutilVue.Afficher("\n Veuillez rentrer votre carte bancaire :");
            dossier.NumCB = Console.ReadLine();
            OutilVue.Afficher("\n Veuillez inqdiquer l'ID voyage :");
            dossier.Id_voyage = Int32.Parse(Console.ReadLine());
            OutilVue.Afficher("\n Veuillez inqdiquer l'ID client :");
            dossier.Id_client = Int32.Parse(Console.ReadLine());


            return dossier;
        }


        public static void AfficherDossier(DossierReservation recup)
        {
            string affichage = "Informations Dossier \r\n\t";
            if (recup.Id_dossier > -1) { affichage += "ID_dossier: " + recup.Id_dossier + "\r\n\t"; }
            if (!string.IsNullOrEmpty(recup.NumCB)) { affichage += "n_CB = '" + recup.NumCB + "'\r\n\t"; }
            if (!string.IsNullOrEmpty(recup.EtatDossier1)) { affichage += "Etat du dossier : '" + recup.EtatDossier1 + "' \r\n\t"; }
            if (!string.IsNullOrEmpty(recup.RaisonAnnul)) { affichage += "Raison d'annulation : '" + recup.RaisonAnnul + "' \r\n\t"; }

            if (recup.Id_voyage > -1) { affichage += "ID_voyage : " + recup.Id_voyage + "  "; }
            if (recup.Id_client > -1) { affichage += "ID_client : " + recup.Id_client + "\r\n"; }

            OutilVue.Afficher(affichage);

        }
    }
}
