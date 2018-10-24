using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TP_Gestion_ETABLISSEMENT.Entities;

namespace TP_Gestion_ETABLISSEMENT.Model
{
    public class UserDB : IUser
    {
        private DB db;
        public User GetLogin(string login, string password)
        {
            User u = null;
            try
            {
                db = new DB();
                string sql = "select * from dbo.[User] where Login = @login and Password = @password";
                //Initialisation de la requete
                db.InitPrepare(sql);
                //passage de valeurs aux parametres de la requete SQL
                db.GetCmd().Parameters.Add("@login", SqlDbType.VarChar, 200);
                db.GetCmd().Parameters.Add("@password", SqlDbType.VarChar, 255);

                db.GetCmd().Parameters["@login"].Value = login;
                db.GetCmd().Parameters["@password"].Value = password;

                SqlDataReader dr = db.ExecuteSELECT();
                
                while (dr.Read())
                {
                    u = new User();
                    u.Id = int.Parse(dr[0].ToString());
                    u.Nom = dr[1].ToString();
                    u.Prenom = dr[2].ToString();
                    u.Login = dr[3].ToString();
                    u.Password = dr[4].ToString();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("erreur udb " + ex.Message.ToString());
            }
            return u;
        }

        public User GetUserById(int idU)
        {
            User u = null;
            try
            {
                db = new DB();
                string sql = "SELECT * FROM dbo.[User] WHERE Id = @Id";
                //Initialisation de la requete
                db.InitPrepare(sql);
                //passage de valeurs aux parametres de la requete SQL
                db.GetCmd().Parameters.Add("@Id", SqlDbType.Int);
                db.GetCmd().Parameters["@Id"].Value = idU;

                SqlDataReader dr = db.ExecuteSELECT();
                while (dr.Read())
                {
                    u = new User();
                    u.Id = int.Parse(dr[0].ToString());
                    u.Nom = dr[1].ToString();
                    u.Prenom = dr[2].ToString();
                    u.Login = dr[3].ToString();
                    u.Password = dr[4].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return u;
        }
    }
}
