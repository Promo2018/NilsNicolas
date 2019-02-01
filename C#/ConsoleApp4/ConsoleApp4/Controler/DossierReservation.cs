using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Controler
{
    class DossierReservation
    {
        public DossierReservation()
        {
            Id_dossier = -1;
            NumCB = null;
            EtatDossier1 = enAttente;
            RaisonAnnul = aucun;
            Id_voyage = -1;
            Id_client = -1;
        }

        public DossierReservation(int id_dossier, string numCB, string etatDossier, string raisonAnnul, int id_voyage, int id_client)
        {
            Id_dossier = id_dossier;
            NumCB = numCB;
            EtatDossier1 = enAttente;
            RaisonAnnul = aucun;
            Id_voyage = id_voyage;
            Id_client = id_client;
        }


        private int id_dossier;
        private string numCB;
        private int id_voyage;
        private int id_client;
        private string etatDossier;
        private string raisonAnnul;
        private string enAttente = EtatDossier.enAttente.ToString();
        private string enCours = EtatDossier.enCours.ToString();
        private string refusee = EtatDossier.refusee.ToString();
        private string acceptee = EtatDossier.acceptee.ToString();
        private string aucun = RaisonAnnulDossier.aucun.ToString();
        private string client = RaisonAnnulDossier.client.ToString();
        private string placesinsufisantes = RaisonAnnulDossier.placesinsufisantes.ToString();



        public int Id_dossier { get => id_dossier; set => id_dossier = value; }
        public string NumCB { get => numCB; set => numCB = value; }
        public int Id_voyage { get => id_voyage; set => id_voyage = value; }
        public int Id_client { get => id_client; set => id_client = value; }
        public string EnAttente { get => enAttente; set => enAttente = value; }
        public string EnCours { get => enCours; set => enCours = value; }
        public string Refusee { get => refusee; set => refusee = value; }
        public string Acceptee { get => acceptee; set => acceptee = value; }
        public string Aucun { get => aucun; set => aucun = value; }
        public string Client { get => client; set => client = value; }
        public string Placesinsufisantes { get => placesinsufisantes; set => placesinsufisantes = value; }
        public string EtatDossier1 { get => etatDossier; set => etatDossier = value; }
        public string RaisonAnnul { get => raisonAnnul; set => raisonAnnul = value; }

        enum EtatDossier
        {
            enAttente = 0,
            enCours = 1,
            refusee = 2,
            acceptee = 3,
        }

        enum RaisonAnnulDossier
        {
            aucun = 0,
            client = 1,
            placesinsufisantes = 2,
        }


    }
}
