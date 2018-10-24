using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TP_Gestion_ETABLISSEMENT.Model
{
    public class DB
    {
        //Pour la connexion a la base de donnée
        private SqlConnection cnx;
        //Pour l'execution des requetes SQL
        private SqlCommand cmd;
        //Pour la recuperation des resultats des requetes SELECT
        private SqlDataReader dr;
        //Pour la recupeartion des resultats des requetes de type MAJ(INSERT, UPDATE et DELETE)
        private int ok;
        
        private void GetConnexion()
        {
            try
            {
                cnx = new SqlConnection("Data Source=.;Initial Catalog=WPF_Gestion_Etablissement;Integrated Security=True");
                cnx.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        } 

        public void InitPrepare(string sql)
        {
            try
            {
                GetConnexion();
                cmd = new SqlCommand(sql, cnx);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ereur commande sql : " + ex.Message.ToString());
            }
        }
        public SqlDataReader ExecuteSELECT()
        {
            try
            {
                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur d'execution select : " + ex.Message.ToString());
            }
            return dr;
        }
        public int ExecuteMAJ()
        {
            try
            {
                ok = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return ok;
        }
        public void CloseConnexion()
        {
            try
            {
                if(cnx != null) {
                    cnx.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public SqlCommand GetCmd()
        {
            return this.cmd;
        }
    }
}
