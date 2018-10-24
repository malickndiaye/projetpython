using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Gestion_ETABLISSEMENT.Entities;

namespace TP_Gestion_ETABLISSEMENT.Model
{
    public interface IUser
    {
        User GetLogin(string login, string password);
        User GetUserById(int idU);
    }
}
