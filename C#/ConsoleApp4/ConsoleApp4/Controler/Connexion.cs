namespace ConsoleApp4.Model
{
    class Connexion
    {
        public Connexion()
        {

        }

        public Connexion(string identifiant, string mdp)
        {
            Identifiant = identifiant;
            Mdp = mdp;

        }


        private string identifiant;
        private string mdp;

        public string Identifiant { get => identifiant; set => identifiant = value; }
        public string Mdp { get => mdp; set => mdp = value; }




    }
}
