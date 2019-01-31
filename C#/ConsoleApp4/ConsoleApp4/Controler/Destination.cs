using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Model
{
    class Destination
    {
        public Destination()
        {


        }

        private int id_destination;
        private string continent;
        private string pays;
        private string region;
        private string descriptif;

        public int Id_destination { get => id_destination; set => id_destination = value; }
        public string Continent { get => continent; set => continent = value; }
        public string Pays { get => pays; set => pays = value; }
        public string Region { get => region; set => region = value; }
        public string Descriptif { get => descriptif; set => descriptif = value; }
    }
}
