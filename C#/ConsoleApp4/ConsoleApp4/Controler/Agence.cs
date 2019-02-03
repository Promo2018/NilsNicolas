using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Controler
{
    class Agence
    {
        public Agence()
        {

        }

        private int id_agence;
        private string nomAgence;

        public int Id_agence { get => id_agence; set => id_agence = value; }
        public string NomAgence { get => nomAgence; set => nomAgence = value; }

    }
}
