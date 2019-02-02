using ConsoleApp4.Model;
using ConsoleApp4.Vue;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleApp4.Controler
{
    class Personne
    {
        public Personne()
        {
            Id_personne = -1;
            Civ = null;
            Nom = null;
            Prenom = null;
            Datenaissance = DateTime.ParseExact("01010001", "ddMMyyyy", CultureInfo.InvariantCulture); 
            Age = -1;
            Adresse = null;
            Tel = null;
            Email = null;
            Client = -1;
            Participant = -1;
            Reduction = -1;

        }

        public Personne(int id_personne, string civ, string nom, string prenom, float reduction)
        {
            Id_personne = id_personne;
            Civ = civ;
            Nom = nom;
            Prenom = prenom;
            Reduction = reduction;

        }

        public Personne(int id_personne, string civ, string nom, string prenom, DateTime datenaissance, string adresse, string tel, string email, int client, int participant, float reduction)
        {
            Id_personne = id_personne;
            Civ = civ;
            Nom = nom;
            Prenom = prenom;
            Datenaissance = datenaissance.Date;
            Adresse = adresse;
            Age = DateTime.Now.Year - datenaissance.Year;
            if (DateTime.Now.Month < datenaissance.Month || DateTime.Now.Month == datenaissance.Month && DateTime.Now.Day < datenaissance.Day)
            { Age--; }
            else
            { }
            Tel = tel;
            Email = email;
            Client = client;
            Participant = participant;
            Reduction = reduction;
        }

        private int id_personne;
        private string civ;
        private string nom;
        private string prenom;
        private DateTime datenaissance;
        private int age;
        private string adresse;
        private string tel;
        private string email;
        private int client;
        private int participant;
        private float reduction;

        public int Id_personne { get => id_personne; set => id_personne = value; }
        public string Civ { get => civ; set => civ = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public DateTime Datenaissance { get => datenaissance; set => datenaissance = value; }
        public int Age { get => age; set => age = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Email { get => email; set => email = value; }
        public int Client { get => client; set => client = value; }
       
        public string Tel { get => tel; set => tel = value; }
        public int Participant { get => participant; set => participant = value; }
        public float Reduction { get => reduction; set => reduction = value; }

        public void Reinit()
        {
            Id_personne = -1;
            civ = null;
            Nom = null;
            Prenom = null;
            Datenaissance = DateTime.ParseExact("01010001", "ddMMyyyy", CultureInfo.InvariantCulture);
            Age = -1;
            Adresse = null;
            Tel = null;
            email = null;
            client = -1;
            participant = -1;
            reduction = -1;
        }

        // cherche une personne dans la BDD puis propose de la modifier et enregistre les modifications
        public static void RechMod()
        {
            bool sema9 = true;

           
            Personne vnul = new Personne();
            // rechercher la personen a partir de ID, nom, prenom et/ou date de naissance
            while (sema9)
            {
                Personne voyageur3 = RecupPers("Voulez vous modifier");
                if (voyageur3.Id_personne==-1)
                {
                    OutilVue.Afficher("Fin de la recherche/modification.");
                    
                }
                else
                {
                    PersonneBDD.Update(voyageur3);

                }
                sema9 = OutilVue.Precedent("continuer de rechercher/modifier des Voyageurs");
            }
        }

        // cree un objet personne, demande a l'utilisateur de setter ses attributs settables, offre la possibilité de modifier cet objet puis l'enregistre dans la BDD
        public static void Nvo()
        {
            //cree un objet personne
            Personne voyageur1 = new Personne();
            bool sema2 = true;
            bool sema4 = true;
            while (sema2 == true)
            {
                //set ses attributs
                voyageur1.Reinit();
                voyageur1 = PersonneVue.Creer();


                bool sema3 = true;
                while (sema3)
                {
                    
                    OutilVue.Afficher("Continuer et Sauvegarder ou Modifier ? \n\t 1. Continuer \n\t 2. Modifier \n\t 3. Abbandonner la Création \n\t");
                    string choix = OutilVue.Demander();
                    switch (choix)
                    {
                        case "1":
                            sema3 = false;
                            break;

                        case "2":
                            //modifier l'objet 
                            PersonneVue.Modifier(ref voyageur1);

                            break;
                        case "3":
                            sema4 = false;
                            sema3 = false;
                            break;

                        default:
                            OutilVue.Afficher("Entree Invalide; Veuillez Saisir \"1\" \"2\" ou \"3\" comme indiqué dans le menu ###");
                            break;

                    }
                }
                if (sema4)
                {
                    //insert BDD
                    PersonneBDD.Ajouter(voyageur1);
                    //verifier que l'insert a marché via la recherche
                    PersonneBDD.RechercherVoyageur(voyageur1);
                    sema2 = OutilVue.Precedent("continuer d'ajouter des Voyageurs");
                }
                else
                {
                    OutilVue.Afficher("### Abbandon de la création d'un Voyageur ###");
                    sema2 = false;
                }

            }
        }

        // affiche la liste de tous les voyageurs
        public static void Tous()
        {
            Personne voyageur1 = new Personne();
            voyageur1.Reinit();
            PersonneBDD.RechercherVoyageur(voyageur1);
        }

        // recupere une personne a partir de son ID/nom/prenom et/ou ddn et la renvoie
        public static Personne RecupPers(string action)
        {

            Personne voyageur1 = new Personne();
            Personne voyageur2 = new Personne();
            Personne vnul = new Personne();
            // rechercher la personen a partir de ID, nom, prenom et/ou date de naissance
            voyageur1.Reinit();
            bool sema10 = true;
            while (sema10)
            {
                sema10 = false;
                List<Personne> listeR = new List<Personne>();
                OutilVue.Afficher("Veuillez saisir les informations suivantes pour trouver le Voyageur que vous souhaiter modifier : Identifiant Unique, Prenom, Nom et Date de Naissance \n\n\t La saisie d'un champ doit être complète et exacte pour fonctionner. Mais pas Besoin de remplir tout les champs. Un champ peut rester vide. \n ");

                Controle.CId2(ref voyageur1);
                Controle.CPrenom2(ref voyageur1);
                Controle.CNom2(ref voyageur1);
                Controle.CDDN2(ref voyageur1);
                if (voyageur1.Id_personne == -1 && voyageur1.Prenom == null && voyageur1.Nom == null && voyageur1.Datenaissance == DateTime.ParseExact("01010001", "ddMMyyyy", CultureInfo.InvariantCulture))
                {
                    OutilVue.Afficher("Aucun critère de selection appliqué"); sema10 = OutilVue.Precedent("recommencer la saisie des critères de recherche");
                }
                // si la personne est trouvee dans la BDD l'affiche et la stoque dans un objet personne
                else
                {
                    listeR = PersonneBDD.RechercherVoyageur(voyageur1);
                    if (listeR.Count == 0)
                    {
                        OutilVue.Afficher("Aucun resultat trouvé");

                    }
                    else
                    {
                        bool sema11 = OutilVue.Precedent(action+" (un de) ce(s) voyageur");
                        if (sema11)
                        {

                            voyageur2.Reinit();
                            switch (listeR.Count)
                            {
                                case 1:
                                    voyageur2 = listeR[0];
                                    break;

                                //si la methode rechercher retourne plusieurs resultat il faut selectionner une des personnes retournée qui est à nouveau recuperée via son ID
                                case int n when n > 1:
                                    OutilVue.Afficher(listeR.Count + " resultats trouvés. Selectionnez l'identifiant unique du voyageur à modifier");
                                    List<int> ids = new List<int>();
                                    foreach (Personne p in listeR)
                                    {
                                        ids.Add(p.Id_personne);
                                    }

                                    bool sema12 = true;
                                    while (sema12)
                                    {
                                        Controle.CId(ref voyageur2);
                                        if (ids.Contains(voyageur2.Id_personne))
                                        {
                                            List<Personne> listeS = PersonneBDD.RechercherVoyageur(voyageur2);
                                            voyageur2 = listeS[0];
                                            sema12 = false;
                                        }
                                        else
                                        {
                                            OutilVue.Afficher("### Entrez l'identifiants de l'un des resultats de la recherche svp ###");
                                        }
                                    }

                                    break;

                                default:
                                    OutilVue.Afficher("Erreur switch du menu modifier voyageur");
                                    break;
                            }

                        }

                        else
                        {
                            sema11 = false;
                            // OutilVue.Afficher("### Abbandon de la modification d'un Voyageur ###");
                        }

                    }

                }


            }
            return voyageur2;
        }

        public static Personne RecupPersDoss(string action)
        {

            Personne voyageur1 = new Personne();
            Personne voyageur2 = new Personne();
            Personne vnul = new Personne();
            // rechercher la personen a partir de ID, nom, prenom et/ou date de naissance
            voyageur1.Reinit();
            bool sema10 = true;
            while (sema10)
            {
                sema10 = false;
                List<Personne> listeR = new List<Personne>();
                OutilVue.Afficher("Veuillez saisir les informations suivantes pour trouver le Voyageur que vous souhaiter modifier : Prenom et Nom \n\n\t La saisie d'un champ doit être complète et exacte pour fonctionner. Mais pas Besoin de remplir tout les champs. Un champ peut rester vide. \n ");

                Controle.CPrenom2(ref voyageur1);
                Controle.CNom2(ref voyageur1);
                if (voyageur1.Prenom == null && voyageur1.Nom == null)
                {
                    OutilVue.Afficher("Aucun critère de selection appliqué"); sema10 = OutilVue.Precedent("recommencer la saisie des critères de recherche");
                }
                // si la personne est trouvee dans la BDD l'affiche et la stoque dans un objet personne
                else
                {
                    listeR = PersonneBDD.RechercherVoyageur(voyageur1);
                    if (listeR.Count == 0)
                    {
                        OutilVue.Afficher("Aucun resultat trouvé");

                    }
                    else
                    {
                        bool sema11 = OutilVue.Precedent(action + " (un de) ce(s) voyageur");
                        if (sema11)
                        {

                            voyageur2.Reinit();
                            switch (listeR.Count)
                            {
                                case 1:
                                    voyageur2 = listeR[0];
                                    break;

                                //si la methode rechercher retourne plusieurs resultat il faut selectionner une des personnes retournée qui est à nouveau recuperée via son ID
                                case int n when n > 1:
                                    OutilVue.Afficher(listeR.Count + " resultats trouvés. Selectionnez l'identifiant unique du voyageur à modifier");
                                    List<int> ids = new List<int>();
                                    foreach (Personne p in listeR)
                                    {
                                        ids.Add(p.Id_personne);
                                    }

                                    bool sema12 = true;
                                    while (sema12)
                                    {
                                        Controle.CId(ref voyageur2);
                                        if (ids.Contains(voyageur2.Id_personne))
                                        {
                                            List<Personne> listeS = PersonneBDD.RechercherVoyageur(voyageur2);
                                            voyageur2 = listeS[0];
                                            sema12 = false;
                                        }
                                        else
                                        {
                                            OutilVue.Afficher("### Entrez l'identifiants de l'un des resultats de la recherche svp ###");
                                        }
                                    }

                                    break;

                                default:
                                    OutilVue.Afficher("Erreur switch du menu modifier voyageur");
                                    break;
                            }

                        }

                        else
                        {
                            sema11 = false;
                            // OutilVue.Afficher("### Abandon de la modification d'un Voyageur ###");
                        }

                    }

                }


            }
            return voyageur2;
        }

    }

}
