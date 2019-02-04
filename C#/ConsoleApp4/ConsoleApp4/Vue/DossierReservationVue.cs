using ConsoleApp4.Controler;
using ConsoleApp4.Model;
using System;
using System.Collections.Generic;

namespace ConsoleApp4.Vue
{
    class DossierReservationVue
    {
        public static DossierReservation CreerDossier()

        {
            DossierReservation dossier = new DossierReservation();
            OutilVue.Afficher("\n Pour creer un Dossier, veuillez renseigner les informations suivantes :");

            //ID client
            OutilVue.Afficher("Client :");
            DossierReservation.SetClient(ref dossier);


            //n° de CB
            Controle.CCB(ref dossier);

            // ID voyage

            DossierReservation.SetVoyage(ref dossier);

            // liste participants
            OutilVue.Dev("liste des participants");

            // assurance
            OutilVue.Dev("assurance voyage");


            return dossier;
        }


        public static void AfficherDossier(DossierReservation recup)
        {
            string affichage = "Informations Dossier \r\n\t";
            if (recup.Id_dossier > -1) { affichage += "ID_dossier: " + recup.Id_dossier + "\r\n\t"; }
            if (!string.IsNullOrEmpty(recup.EtatDossier1)) { affichage += "Etat du dossier : '" + recup.EtatDossier1 + "' \r\n\t"; }
            if (recup.Id_client > -1) { affichage += "ID_client : " + recup.Id_client + "  "; }
            if (recup.Id_voyage > -1) { affichage += "ID_voyage : " + recup.Id_voyage + "\r\n\t"; }

            if (!string.IsNullOrEmpty(recup.NumCB)) { affichage += "n_CB = '" + recup.NumCB + "'\r\n\t"; }
            if (!string.IsNullOrEmpty(recup.RaisonAnnul)) { affichage += "Raison d'annulation : '" + recup.RaisonAnnul + "' \r\n\t"; }



            OutilVue.Afficher(affichage);

        }


        // modifie un objet personne par attribut settable

        public static void ModifierDoss(ref DossierReservation recup)
        {
            string choix;
            bool sema2;

            do
            {

                List<string> listmenum = new List<string>() { "1", "2", "3", "4", "5" };
                do
                {
                    OutilVue.Afficher("\r\n Veuillez indiquer le champ que vous souhaitez modifier \r\n" +
                        "\n\t 1. Client  \n\t 2. Numéro de CB  \n\t 3. Voyage \n\t 4. Liste des Participants \n\t 5. Assurance \n\t");
                    choix = OutilVue.Demander();
                    if (!listmenum.Contains(choix))
                    {
                        OutilVue.Afficher("### Entree Invalide; Veuillez Saisir \"1\", \"2\", \"3\", \"4\" ou \"5\" comme indiqué dans le menu ###");
                    }
                }
                while (!listmenum.Contains(choix));

                switch (choix)
                {
                    case "1":
                        DossierReservation.SetClient(ref recup);
                            break;
                    case "2":
                        Controle.CCB(ref recup);
                        break;
                    case "3":
                        DossierReservation.SetVoyage(ref  recup);
                        break;
                    case "4":
                        OutilVue.Dev("Afficher/modifier le(s) participant(s) de ce dossier");
                        break;
                    case "5":
                        OutilVue.Dev("Afficher/modifier la/les Assurance(s) de ce dossier");
                        break;

                    default:
                        OutilVue.Afficher("Erreur menu modifier objet Dossier REs");
                        break;
                }

                DossierReservationVue.AfficherDossier(recup);
                sema2 = OutilVue.Precedent("modifier un autre donnée ou enregistrer");

            }
            while (sema2);
        }
    }

    
}
