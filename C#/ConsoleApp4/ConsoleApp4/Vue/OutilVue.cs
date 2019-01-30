using System;

namespace ConsoleApp4.Vue
{
    class OutilVue
    {
        //Constructeur
        public OutilVue()
        {
        }

        //cree un separateur visuel composé de blocs de 5* séparés, le bloc est répété 'nbbloc' fois 
        public static void Sep(int nbbloc)
        {
            string ligne = "";
            string bloc = "***** ";
            for (int i = 0; i < nbbloc; i++)
                ligne = ligne + bloc;
            Console.WriteLine(ligne);
        }
        //séparateur visuel dont le motif de base 'motif' est reproduit 'repetition' fois
        public static void Sep(int repetition, string motif)
        {
            string ligne = "";
            string bloc = motif;
            for (int i = 0; i < repetition; i++)
                ligne = ligne + bloc;
            Console.WriteLine(ligne);
        }
        // constructeur
        public void Vueconsole()
        {

        }

        //affiche une message sur la console pour l'utilisateur
        public static void Afficher(string texte)
        {
            Console.WriteLine(texte);
        }

        //affiche une message sur la console pour l'utilisateur
        public static void Afficher(DateTime date)
        {
            Console.WriteLine(date.ToString("dd/MM/yyyy"));
        }

        
        // demander à l'utilisateur de la console d'entrer une chaine de caractères et la renvoie
        public static string Demander(string parametre)

        {
            OutilVue.Afficher("\n Entrer " + parametre);
            string retour= Console.ReadLine();
            return retour;
        }

        // fait apparaitre un champ que l'utilisateur de la console peut remplir et renvoie ce que l'utilisateur a ecrit
        public static string Demander()

        {
            string retour = Console.ReadLine();
            return retour;
        }
        //Arrete le deroulement du programme et demande à l'intervention de l'utilisateur pour poursuivre
        public static void Pause()
        {
            OutilVue.Afficher(@"Appuyez sur ""Entrer"" pour continuer");
            Console.ReadKey();
        }
        //ferme la console et le programme
        public static void Quitter()
        {
            OutilVue.Sep(6);
            Console.WriteLine("Fermeture du programme");
            OutilVue.Pause();
            Environment.Exit(0);
        }
        //methode qui renvoie "true" si l'utilisateur veut repeter la meme opération "false" si il veut revenir au menu précédent et qui boucle tant qu il n a pas répondu
        public static bool Precedent()
        {
            bool sema=true;
            bool semal = false;
            while (semal == false)
            {
                OutilVue.Afficher("\n Voulez-vous continuer? o/n (si non, retour au menu précedent)");   
                string saisie = OutilVue.Demander();
                switch (saisie)
                {
                    case "o":
                        sema = true;
                        semal = true;
                        break;
                    case "n":
                        sema = false;
                        semal = true;
                        break;
                    default:
                        Console.WriteLine("\n  ### Vous n'avez pas repondu à la question par \"o\" ou \"n\"! ### ");
                        break;
                }
            }
            return sema;         
        }
        // meme methode mais avec un message personnalisé
        public static bool Precedent(string quoi)
        {
            bool sema = true;
            bool semal = false;
            while (semal == false)
            {
                OutilVue.Afficher("\n Voulez-vous "+quoi+"? o/n (si non, retour au menu précedent)");
                string saisie = OutilVue.Demander();
                switch (saisie)
                {
                    case "o":
                        sema = true;
                        semal = true;
                        break;
                    case "n":
                        sema = false;
                        semal = true;
                        break;
                    default:
                        Console.WriteLine("\n  ### Vous n'avez pas repondu à la question par \"o\" ou \"n\"! ### ");
                        break;
                }
            }
            return sema;
        }
        //idem mais on definit ce qui se passe dans l'alternative
        public static bool Precedent(string quoi, string sinon)
        {
            bool sema = true;
            bool semal = false;
            while (semal == false)
            {
                OutilVue.Afficher("\n Voulez-vous " + quoi + "? o/n (si non, "+sinon+" )");
                string saisie = OutilVue.Demander();
                switch (saisie)
                {
                    case "o":
                        sema = true;
                        semal = true;
                        break;
                    case "n":
                        sema = false;
                        semal = true;
                        break;
                    default:
                        Console.WriteLine("\n  ### Vous n'avez pas repondu à la question par \"o\" ou \"n\"! ### ");
                        break;
                }
            }
            return sema;
        }
        public static void Dev(string fonction)
        {
            OutilVue.Afficher("\n");
            OutilVue.Sep(7, "##### ");
            OutilVue.Afficher(fonction + " non disponible. La Fonction " + fonction + " est en cours de developpement");
            OutilVue.Pause();

        }

        //pour afficher un numero de telephone . à partir d'une chaine de caracteres/chiffres continus (cree des blocs de caracteres de taille 'section' séparé par un 'separateur' 
        public static string Espacer(string sansespace, int section, string separateur)
        {
            int i;
            double taille = (sansespace.Length) / Convert.ToDouble(section);
            int roundtaille = Convert.ToInt32(Math.Ceiling(taille));
            string espace = "";
            for (i = 0; i < roundtaille - 1; i++)
            {
                espace = espace + (sansespace.Substring(i * section, section) + separateur);
            }
            espace = espace + sansespace.Substring((roundtaille - 1) * section);

            return espace;
        }
    }
}
