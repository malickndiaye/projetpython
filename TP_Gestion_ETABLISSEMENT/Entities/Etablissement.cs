using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Gestion_ETABLISSEMENT.Entities
{
    public class Etablissement
    {
        public int Id { get; set; }
        public string NomE { get; set; }
        public string VilleE { get; set; }
        public string TelE { get; set; }
        public User IdU { get; set; }

        public override string ToString()
        {
            return NomE + "   -  " + VilleE;
        }
    }
}
