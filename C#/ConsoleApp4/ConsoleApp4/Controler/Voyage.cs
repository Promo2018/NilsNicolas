using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Controler
{
    class Voyage
    {
        public Voyage()
        {
            Id_voyage = -1;
            DateAller = DateTime.ParseExact("01010001", "ddMMyyyy", CultureInfo.InvariantCulture);
            DateRetour = DateTime.ParseExact("01010001", "ddMMyyyy", CultureInfo.InvariantCulture);
            PlaceDispo = -1;
            TarifTC = null;
            Id_destination = -1;
            Id_agence = -1;

        }

        public Voyage(int id_voyage, DateTime dateAller, DateTime dateRetour, int placeDispo, string tarifTC, int id_destination, int id_agence)
        {
            Id_voyage = id_voyage;
            DateAller = dateAller;
            DateRetour = dateRetour;
            PlaceDispo = placeDispo;
            TarifTC = tarifTC;
            Id_destination = id_destination;
            Id_agence = id_voyage;
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
