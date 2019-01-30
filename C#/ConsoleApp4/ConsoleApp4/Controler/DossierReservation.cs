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

        }

        private int id_dossier;
        private string numCB;
        private decimal prixTotal;
        private int id_voyage;
        private int id_client;

        public int Id_dossier { get => id_dossier; set => id_dossier = value; }
        public string NumCB { get => numCB; set => numCB = value; }
        public decimal PrixTotal { get => prixTotal; set => prixTotal = value; }
        public int Id_voyage { get => id_voyage; set => id_voyage = value; }
        public int Id_client { get => id_client; set => id_client = value; }

        enum EtatDossier
        {
            enAttente = 0,
            enCours = 1,
            refusee = 2,
            acceptee = 3,
        }

        enum RaisonAnnulDossier
        {
            client = 1,
            placesinsufisantes = 2,
        }


    }
}
