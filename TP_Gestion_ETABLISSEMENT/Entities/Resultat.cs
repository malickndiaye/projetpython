using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Gestion_ETABLISSEMENT.Entities
{
    public class Resultat
    {
        public int Id { get; set; }
        public string Examen { get; set; }
        public int Annee { get; set; }
        public float Valeur { get; set; }
        public Etablissement IdE { get; set; }
    }
}
