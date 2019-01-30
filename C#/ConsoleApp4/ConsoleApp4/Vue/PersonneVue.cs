using ConsoleApp4.Controler;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleApp4.Vue
{
    class PersonneVue
    {
        public static Personne Creer()
        {
            Personne voyageurv = new Personne();
            OutilVue.Afficher("\n Pour ajouter un voyageur, veuillez renseigner les informations suivantes :");

            Controle.CCivilite(ref voyageurv);

            Controle.CPrenom(ref voyageurv);

            Controle.CNom(ref voyageurv);

            Controle.CDDN(ref voyageurv);

            Controle.CAdresse(ref voyageurv);

            Controle.CTel(ref voyageurv);

            Controle.CEmail(ref voyageurv);

            PersonneVue.AfficherVoyageur(voyageurv);

            return voyageurv;
        }


        // Affiche les données d une personne stockée dans un objet "personne"

        public static void AfficherVoyageur(Personne voyageura)
        {
            string affichage = "Informations Voyageur \r\n\t";
            if (voyageura.Id_personne > -1) { affichage += "Identifiant unique: " + voyageura.Id_personne + "\r\n\t"; }
            if (!string.IsNullOrEmpty(voyageura.Civ)) { affichage += voyageura.Civ + " "; }
            if (!string.IsNullOrEmpty(voyageura.Prenom)) { affichage += voyageura.Prenom + " "; }
            if (!string.IsNullOrEmpty(voyageura.Nom)) { affichage += voyageura.Nom; }
            if (!string.IsNullOrEmpty(voyageura.Civ) || !string.IsNullOrEmpty(voyageura.Prenom) || !string.IsNullOrEmpty(voyageura.Nom)) { affichage += "\r\n\t"; }
            if (voyageura.Datenaissance > DateTime.ParseExact("01010001", "ddMMyyyy", CultureInfo.InvariantCulture)) { affichage += "né le " + voyageura.Datenaissance.ToString("dd / MM / yy"); }
            if (voyageura.Age > -1) { affichage += " (" + voyageura.Age + " ans)"; }
            if (voyageura.Age > -1 || voyageura.Datenaissance > DateTime.ParseExact("01010001", "ddMMyyyy", CultureInfo.InvariantCulture)) { affichage += "\r\n\t"; }
            if (!string.IsNullOrEmpty(voyageura.Adresse)) { affichage += "Adresse : " + voyageura.Adresse + "\r\n\t"; }
            if (!string.IsNullOrEmpty(voyageura.Tel)) { affichage += ("Tel : " + (OutilVue.Espacer(voyageura.Tel,2, " ")) + "     "); }
            if (!string.IsNullOrEmpty(voyageura.Email)) { affichage += "E-mail : " + voyageura.Email; }
            if (!string.IsNullOrEmpty(voyageura.Tel) || !string.IsNullOrEmpty(voyageura.Email)) { affichage += "\r\n\t"; }
            if (voyageura.Client == 0) { affichage += "Client : non "; }
            if (voyageura.Client == 1) { affichage += "Client : oui "; }
            if (voyageura.Client > -1 && voyageura.Participant > -1) { affichage += " | ";}
            if (voyageura.Participant == 0) { affichage += "Participant : non "; }
            if (voyageura.Participant == 1) { affichage += "Participant : oui "; }
            if (voyageura.Participant > -1 && voyageura.Reduction > -1) { affichage += " | "; }
            if (voyageura.Reduction > -1) { affichage += "Reduction : "+voyageura.Reduction; }
            if (voyageura.Client > -1 || voyageura.Participant > -1 || voyageura.Reduction > -1) { affichage += "\r\n\t"; }

            OutilVue.Afficher(affichage);

        }

        public static void Modifier(ref Personne recup)
        {
            string choix;
            bool sema2;

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

                PersonneVue.AfficherVoyageur(recup);
                sema2 = OutilVue.Precedent("modifier un autre donnée de cette personne ou enregistrer");

            }
            while (sema2);
        }
    }
}
