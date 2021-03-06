﻿using ConsoleApp4.Vue;
using System;
using System.Collections.Generic;
using System.Globalization;
// using pour le controleur d'expressions
using System.Text.RegularExpressions;

namespace ConsoleApp4.Controler
{
    class Controle
    {
        public Controle()
        {
        }

        // retrourne vrai si une saisie est bien dans la liste des options possibles
        public static bool Choix(string saisie, List<string> options)
        {
            bool ok;
            if (options.Contains(saisie))
            { ok = true; }
            else
            { ok = false; }
            return ok;
        }

        //retourne vrai si tout les caracteres d'une saisie sont des lettres
        public static bool Onlyletters(string saisie)
        {
            bool retour = true;
            char[] lettres = saisie.ToCharArray();
            int position = 0;
            foreach (char c in lettres)
            {
                position = position + 1;
                if (Char.IsLetter(c) == false)
                {
                    retour = false;
                    OutilVue.Afficher("Le mot que vous avez rentré contient un chiffre ou un caractere inhabituel en position " + position);
                }
                else { }
            }
            return retour;
        }

        //retourne vrai si la chaine de caracteres est numérique
        public static bool OnlyNumber(string saisie)
        {
            bool retour = Int32.TryParse(saisie, out int chiffre);
            return retour;
        }

        //retourne vrai si la saisie est vide ou nulle
        public static bool ZeroOuVide(string saisie)
        {
            bool retour = false;

            if (String.IsNullOrEmpty(saisie))
            {
                retour = true;
                OutilVue.Afficher("### Ce champ n'a pas été rempli ###");
            }
            else { }

            return retour;

        }

        //verifie le nombre de caracteres d'une saisie
        public static bool Size(string saisie, int taille)
        {
            bool retour = (saisie.Length == taille);
            return retour;
        }
        //verifie si l'entree correspond bien a une date MMJJAAAA en 8 chiffre et dans le futur (>aujourd'hui)
        public static bool Date(string saisie, out DateTime datesortie)
        {
            datesortie = DateTime.ParseExact("01010001", "ddMMyyyy", CultureInfo.InvariantCulture);

            bool retour = false;
            if (Controle.OnlyNumber(saisie) | Controle.Size(saisie, 8))
            {

                try
                {
                    datesortie = DateTime.ParseExact(saisie, "ddMMyyyy", CultureInfo.InvariantCulture); ;
                    OutilVue.Afficher(datesortie);
                    if (datesortie > DateTime.Today)
                    {
                        OutilVue.Afficher("Merci d'indiquer une date anterieur a aujourd'hui");
                    }
                    else
                    {
                        retour = true;
                    }
                }
                catch
                {
                    OutilVue.Afficher("Cette entrée ne correspond pas à une date qui existe");

                }
            }
            else
            {
                OutilVue.Afficher("Veuillez rentrer la date de naissance sous la forme d'un nombre à 8 chiffres svp");

            }
            return retour;

        }
        //Controle de la date de naissance

        public static void CDDN(ref Personne voyageur1)
        {
            bool sema8 = true;
            string saisiedate;


            while (sema8)
            {
                if (Controle.Date((saisiedate = OutilVue.Demander("Date de Naissance au format JJMMAAAA")), out DateTime sortie))
                {
                    sema8 = false;
                    voyageur1.Datenaissance = sortie;

                }
                else
                {
                    OutilVue.Afficher("Format de date non valide");
                }

            }


        }

        //controle pour le select de la date de naissance
        public static void CDDN2(ref Personne voyageur1)
        {
            bool sema8 = true;
            while (sema8)
            {
                string saisiedate = OutilVue.Demander("Date de Naissance au format JJMMAAAA");
                if (ZeroOuVide(saisiedate))
                {
                    sema8 = false;
                }
                else
                {

                    if (Controle.Date(saisiedate, out DateTime sortie))
                    {
                        sema8 = false;
                        voyageur1.Datenaissance = sortie;

                    }
                    else
                    {
                        OutilVue.Afficher("Format de date non valide");
                    }


                }
            }


        }

        //  Controle de la civilité
        public static void CCivilite(ref Personne voyageurv)
        {
            bool sema1 = true;
            while (sema1)
            {
                List<string> civi = new List<string> { "M", "MME" };
                voyageurv.Civ = OutilVue.Demander("la CIVILITE. M ou MME").ToUpper();
                if (Controle.Choix(voyageurv.Civ, civi))
                {
                    sema1 = false;
                }
                else
                {
                    OutilVue.Afficher("\n\t ### Erreur! Veuillez ecrire M ou MME pour designer la civilité ###");
                }
            }

        }

        // Controle du nom pour l'insert

        public static void CNom(ref Personne voyageurv)
        {
            bool sema3 = true;
            bool sema4 = true;
            bool sema2 = true;
            while (sema2 || sema3 || sema4)
            {
                voyageurv.Nom = OutilVue.Demander("NOM").ToUpper();
                if (Controle.ZeroOuVide(voyageurv.Nom))
                {

                }
                else
                {
                    sema2 = false;
                    if (Controle.OnlyNumber(voyageurv.Nom))
                    {
                        OutilVue.Afficher("\n\t ### Erreur! Vous n'avez utilisé que des chiffres. Veuillez utiliser des lettres pour ecrire le nom ###");
                    }
                    else
                    {
                        sema3 = false;

                        if (Controle.Onlyletters(voyageurv.Nom))
                        {
                            sema4 = false;
                        }
                        else
                        {
                            if (OutilVue.Precedent("continuer tout de même", "Saisissez le nom de nouveau"))
                            {
                                sema4 = false;
                            }
                            else
                            {

                            }
                        }

                    }
                }
            }
        }

        // controle du nom pour le select
        public static void CNom2(ref Personne voyageurv)
        {
            bool sema3 = true;
            bool sema4 = true;
            bool sema2 = true;
            while (sema2 || sema3 || sema4)
            {
                string saisie = OutilVue.Demander("NOM").ToUpper();
                if (Controle.ZeroOuVide(saisie))
                {
                    sema2 = false; sema3 = false; sema4 = false;
                }
                else
                {
                    sema2 = false;
                    if (Controle.OnlyNumber(saisie))
                    {
                        OutilVue.Afficher("\n\t ### Erreur! Vous n'avez utilisé que des chiffres. Veuillez utiliser des lettres pour ecrire le nom ###");
                    }
                    else
                    {
                        sema3 = false;

                        if (Controle.Onlyletters(saisie))
                        {
                            sema4 = false;
                            voyageurv.Nom = saisie;
                        }
                        else
                        {
                            if (OutilVue.Precedent("continuer tout de même", "Saisissez le nom de nouveau"))
                            {
                                sema4 = false;
                                voyageurv.Nom = saisie;
                            }
                            else
                            {

                            }
                        }

                    }
                }
            }
        }

        // controle prenom 

        public static void CPrenom(ref Personne voyageurv)
        {
            bool sema3 = true;
            bool sema4 = true;
            bool sema2 = true;
            while (sema2 || sema3 || sema4)
            {
                voyageurv.Prenom = OutilVue.Demander("prenom").ToLower();
                if (Controle.ZeroOuVide(voyageurv.Prenom))
                {

                }
                else
                {
                    sema2 = false;
                    if (Controle.OnlyNumber(voyageurv.Prenom))
                    {
                        OutilVue.Afficher("\n\t ### Erreur! Vous n'avez utilisé que des chiffres. Veuillez utiliser des lettres pour ecrire le prenom ###");
                    }
                    else
                    {
                        sema3 = false;

                        if (Controle.Onlyletters(voyageurv.Prenom))
                        {
                            sema4 = false;
                        }
                        else
                        {
                            if (OutilVue.Precedent("continuer tout de même", "Saisissez le prenom de nouveau"))
                            {
                                sema4 = false;
                            }
                            else
                            {

                            }
                        }
                    }
                }
            }
        }

        //saisie prenom pour le select 

        public static void CPrenom2(ref Personne voyageurv)
        {
            bool sema3 = true;
            bool sema4 = true;
            bool sema2 = true;
            while (sema2 || sema3 || sema4)
            {
                string saisie = OutilVue.Demander("prenom").ToLower();
                if (Controle.ZeroOuVide(saisie))
                {
                    sema2 = false; sema3 = false; sema4 = false;
                }
                else
                {
                    sema2 = false;
                    if (Controle.OnlyNumber(saisie))
                    {
                        OutilVue.Afficher("\n\t ### Erreur! Vous n'avez utilisé que des chiffres. Veuillez utiliser des lettres pour ecrire le prenom ###");
                    }
                    else
                    {
                        sema3 = false;

                        if (Controle.Onlyletters(saisie))
                        {
                            sema4 = false;
                            voyageurv.Prenom = saisie;
                        }
                        else
                        {
                            if (OutilVue.Precedent("continuer tout de même", "Saisissez le prenom de nouveau"))
                            {
                                voyageurv.Prenom = saisie;
                                sema4 = false;
                            }
                            else
                            {

                            }
                        }
                    }
                }
            }
        }

        // controle pour l'adresse e-mail facultatif
        public static void CEmail2(ref Personne voyageurv)
        {
            bool sema = false;
            string motif = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            do
            {
                string saisie = OutilVue.Demander("E-mail");

                if (saisie != "")
                {
                    Match isemail = Regex.Match(saisie, motif, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                    sema = isemail.Success;
                    if (!sema)
                    { OutilVue.Afficher("### Rentrez une adresse e-mail valide !!! ###"); }
                    else { voyageurv.Email = saisie; }

                }
                else { OutilVue.Afficher("Pas d'adresse e-mail saisie"); sema = true; }
            }
            while (!sema);

        }

        // controle pour une adresse e-mail obligatoire
        public static void CEmail(ref Personne voyageurv)
        {
            bool sema = false;
            string motif = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            do
            {
                string saisie = OutilVue.Demander("E-mail");

                if (saisie != "")
                {
                    Match isemail = Regex.Match(saisie, motif, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                    sema = isemail.Success;
                    if (!sema)
                    { OutilVue.Afficher("### Rentrez une adresse e-mail valide !!! ###"); }
                    else { voyageurv.Email = saisie; }

                }
                else { OutilVue.Afficher("Remplir ce champ est obligatoire"); }
            }
            while (!sema);

        }

        // Controle pour l'adresse
        public static void CAdresse(ref Personne voyageurv)
        {
            bool sema = true;

            while (sema)
            {
                string saisie = OutilVue.Demander("Adresse");

                if (ZeroOuVide(saisie) | OnlyNumber(saisie))
                {
                    OutilVue.Afficher("Erreur saisie adresse. Renseignez une adresse svp");
                }
                else { sema = false; voyageurv.Adresse = saisie; }

            }

        }
        //controle pour le numero de telephone obligatoire

        public static void CTel(ref Personne voyageurv)
        {
            bool sema = false;
            string motif = "(0|\\+33|0033)[1-9][0-9]{8}"; // @"^ (?: (?:\+| 00)33[\s.-]{ 0,3} (?:\(0\)[\s.-]{0,3})?|0)[1-9] (?:(?:[\s.-]?\d{2}){4}|\d{2}(?:[\s.-]?\d{3}){2})$";
            do
            {
                string saisie = OutilVue.Demander("n° de telephone");

                if (saisie != "")
                {
                    Match istel = Regex.Match(saisie, motif, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                    sema = istel.Success;
                    if (!sema)
                    { OutilVue.Afficher("### Rentrez un numero de telephone valide !!! ###"); }
                    else { voyageurv.Tel = saisie; }

                }
                else { OutilVue.Afficher("numero de telephone obligatoire"); }
            }
            while (!sema);

        }

        //controle de saisie de l'Id pour le select
        public static void CId2(ref Personne voyageur1)
        {
            bool sema8 = true;
            while (sema8)
            {
                string saisie = OutilVue.Demander("Identifiant Unique");
                if (ZeroOuVide(saisie))
                {
                    sema8 = false;
                }
                else
                {
                    if (OnlyNumber(saisie))
                    {
                        sema8 = false;
                        voyageur1.Id_personne = Int32.Parse(saisie);
                    }
                    else
                    {

                    }

                }
            }

        }

        //controle de saisie de l'Id personne obligatoire
        public static void CId(ref Personne voyageur1)
        {
            bool sema8 = true;
            while (sema8)
            {
                string saisie = OutilVue.Demander("Identifiant Unique");
                if (ZeroOuVide(saisie))
                {
                    OutilVue.Afficher("Ce champ est obligatoire");
                }
                else
                {
                    if (OnlyNumber(saisie))
                    {
                        sema8 = false;
                        voyageur1.Id_personne = Int32.Parse(saisie);
                    }
                    else
                    {

                    }

                }
            }

        }

        //controle de saisie de l'Id voyage obligatoire
        public static void CIdVoy(ref DossierReservation dossier1)
        {
            bool sema8 = true;
            while (sema8)
            {
                string saisie = OutilVue.Demander("Id Voyage");
                if (ZeroOuVide(saisie))
                {
                    OutilVue.Afficher("Ce champ est obligatoire");
                }
                else
                {
                    if (OnlyNumber(saisie))
                    {
                        sema8 = false;
                        dossier1.Id_voyage = Int32.Parse(saisie);
                    }
                    else
                    {

                    }

                }
            }

        }

        //controle de saisie d'un Id client obligatoire
        public static void CIdClient(ref DossierReservation dossier1)
        {
            bool sema8 = true;
            while (sema8)
            {
                string saisie = OutilVue.Demander("Identifiant Unique");
                if (ZeroOuVide(saisie))
                {
                    OutilVue.Afficher("Ce champ est obligatoire");
                }
                else
                {
                    if (OnlyNumber(saisie))
                    {
                        sema8 = false;
                        dossier1.Id_client = Int32.Parse(saisie);
                    }
                    else
                    {

                    }

                }
            }

        }

        //controle de saisie de l'Id dossier obligatoire
        public static int CIdDoss(ref DossierReservation dossier1)
        {
            bool sema8 = true;
            while (sema8)
            {
                string saisie = OutilVue.Demander("Numero de dossier");
                if (ZeroOuVide(saisie))
                {
                    OutilVue.Afficher("Ce champ est obligatoire");
                }
                else
                {
                    if (OnlyNumber(saisie))
                    {
                        sema8 = false;
                        dossier1.Id_dossier = Int32.Parse(saisie);
                    }
                    else
                    {

                    }

                }
            }
            return dossier1.Id_dossier;
        }

        //controle de saisie de l'Id dossier pour le select
        public static int CIdDoss2(ref DossierReservation dossier1)
        {
            bool sema8 = true;
            while (sema8)
            {
                string saisie = OutilVue.Demander("Numero de dossier");
                if (ZeroOuVide(saisie))
                {
                    sema8 = false;
                }
                else
                {
                    if (OnlyNumber(saisie))
                    {
                        sema8 = false;
                        dossier1.Id_dossier = Int32.Parse(saisie);
                    }
                    else
                    {

                    }

                }
            }
            return dossier1.Id_dossier;
        }

        //controle de saisie de l'Id client facultatif
        public static int CIdClient2(ref DossierReservation dossier1)
        {
            bool sema8 = true;
            while (sema8)
            {
                string saisie = OutilVue.Demander("Identifiant unique");
                if (ZeroOuVide(saisie))
                {
                    sema8 = false;
                }
                else
                {
                    if (OnlyNumber(saisie))
                    {
                        sema8 = false;
                        dossier1.Id_client = Int32.Parse(saisie);
                    }
                    else
                    {

                    }

                }
            }
            return dossier1.Id_client;

        }

        //methode qui demande un numéro de CB et retourne un numéro valide ou rien
        public static string DCB()
        {
            string ncb;
            bool sema = false;
            string motif = @"^([4]{1})([0-9]{12,15})$";
            do
            {
                ncb = OutilVue.Demander("Numero de Carte Bancaire");

                if (ncb != "")
                {
                    Match isncb = Regex.Match(ncb, motif, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                    sema = isncb.Success;
                    if (!sema)
                    { OutilVue.Afficher("### Rentrez un numero de carte bancaire valide !!! ###"); }
                    else
                    {

                    }

                }
                else { }
            }
            while (!sema);

            return ncb;
        }

        // demande un numero de CB obligatoire et le rentre dans les parametres d un dossier
        public static void CCB(ref DossierReservation dossier)
        {
            string ncb = DCB();
            if (ZeroOuVide(ncb))
            {
                OutilVue.Afficher("Saisie du Numero de Carte Bancaire Obligatoire");
            }
            else
            {
                dossier.NumCB = ncb;

            }
        }



    }


}




