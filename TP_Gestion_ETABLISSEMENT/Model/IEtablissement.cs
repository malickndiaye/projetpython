using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Gestion_ETABLISSEMENT.Entities;

namespace TP_Gestion_ETABLISSEMENT.Model
{
    public interface IEtablissement
    {
        bool Add(Etablissement e);
        bool Delete(int IdE);
        bool Update(Etablissement e);
        List<Etablissement> Liste();
        List<Resultat> GetResultatsByEtablissement(int IdE);
        Resultat GetResultatsByEtablissementAndYear(int IdE, int annee);
    }
}
