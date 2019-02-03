using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Controller
{
    class Assurance
    {
        public Assurance()
        {

        }

        private int id_assurance;
        private string type_asssurance;
        private float prix;

        public int Id_assurance { get => id_assurance; set => id_assurance = value; }
        public string Type_asssurance { get => type_asssurance; set => type_asssurance = value; }
        public float Prix { get => prix; set => prix = value; }
       
    }
}
