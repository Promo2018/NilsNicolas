using System;
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

        public Personne(int id_personne, string civ, string nom, string prenom, DateTime datenaissance, int age, string adresse, string tel, string email, int client, int participant, float reduction)
        {
            Id_personne = id_personne;
            Civ = civ;
            Nom = nom;
            Prenom = prenom;
            Datenaissance = datenaissance.Date;
            Adresse = adresse;
            Age = age;
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
    }


}
