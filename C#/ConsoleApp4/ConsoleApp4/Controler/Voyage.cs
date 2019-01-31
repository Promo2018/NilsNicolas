using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Controler
{
    class Voyage
    {
        public Voyage()
        {

        }

        private int id_voyage;
        private DateTime dateAller;
        private DateTime dateRetour;
        private int placeDispo;
        private string tarifTC;
        private int id_destination;
        private int id_agence;

        public int Id_voyage { get => id_voyage; set => id_voyage = value; }
        public DateTime DateAller { get => dateAller; set => dateAller = value; }
        public DateTime DateRetour { get => dateRetour; set => dateRetour = value; }
        public int PlaceDispo { get => placeDispo; set => placeDispo = value; }
        public string TarifTC { get => tarifTC; set => tarifTC = value; }
        public int Id_destination { get => id_destination; set => id_destination = value; }
        public int Id_agence { get => id_agence; set => id_agence = value; }
    }
}
