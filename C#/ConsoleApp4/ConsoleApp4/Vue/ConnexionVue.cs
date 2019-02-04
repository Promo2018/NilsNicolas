using System;
using ConsoleApp4.Model;
using System.Data;

namespace ConsoleApp4.Vue
{
    class ConnexionVue
    {
        public ConnexionVue()
        {

        }

        public static Connexion Authentification()
        {
            //Message D'acceuil
            OutilVue.Sep(6); OutilVue.Sep(6);
            Console.WriteLine("Bonjour Bienvenue dans BoVoyage \"Intranet \"");
            OutilVue.Sep(6); OutilVue.Sep(6);
            OutilVue.Pause();


            OutilVue.Afficher("");
            OutilVue.Afficher("\r\n\t***********************************************");
            OutilVue.Afficher("\tVeuillez entrer vos identifiants :");


            OutilVue.Afficher("\tIdentifiant :");
            Connexion connect = new Connexion();
            connect.Identifiant = OutilVue.Demander().ToUpper();

            OutilVue.Afficher("\tMot de passe :");
            connect.Mdp = OutilVue.Demander();

            if (connect.Identifiant == "ADMIN" && connect.Mdp == "password")
            {
                MenuP acceuil = new MenuP();
            }
            else
            {
                OutilVue.Afficher("Identifiants incorrects, veuillez essayer à nouveau.");
                Authentification();
            }
            return connect;
        }
    }
}