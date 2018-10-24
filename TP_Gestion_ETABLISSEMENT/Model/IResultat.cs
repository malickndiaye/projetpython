using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Gestion_ETABLISSEMENT.Entities;

namespace TP_Gestion_ETABLISSEMENT.Model
{
    public interface IResultat
    {
        bool Add(Resultat r);
        bool Delete(int idR);
        bool Update(Resultat r);
        List<Resultat> Liste();
        double GetMoyenneNationalByYear(int annee);
    }
}
