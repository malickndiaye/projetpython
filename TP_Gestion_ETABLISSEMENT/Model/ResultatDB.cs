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
    public class ResultatDB : IResultat
    {
        private bool bol;
        private DB db;
        public bool Add(Resultat r)
        {
            string sql = "INSERT INTO dbo.[Resultat](Examen, Annee, Valeur, IdE)  VALUES(@Examen, @Annee, @Valeur, @IdE)";
            try
            {
                db = new DB();
                db.InitPrepare(sql);
                db.GetCmd().Parameters.Add("@Examen", SqlDbType.VarChar, 100);
                db.GetCmd().Parameters.Add("@Annee", SqlDbType.Int);
                db.GetCmd().Parameters.Add("@Valeur", SqlDbType.Float, 53);
                db.GetCmd().Parameters.Add("@IdE", SqlDbType.Int);

                db.GetCmd().Parameters["@Examen"].Value = r.Examen;
                db.GetCmd().Parameters["@Annee"].Value = r.Annee;
                db.GetCmd().Parameters["@Valeur"].Value = r.Valeur;
                db.GetCmd().Parameters["@IdE"].Value = r.IdE;

                if(db.ExecuteMAJ() != 0)
                {
                    bol = true;
                }
                else
                {
                    bol = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return bol;
        }

        public bool Delete(int idR)
        {
            throw new NotImplementedException();
        }

        public double GetMoyenneNationalByYear(int annee)
        {
            throw new NotImplementedException();
        }

        public List<Resultat> Liste()
        {
            List<Resultat> l_resultat = new List<Resultat>();
            string sql = "SELECT * FROM dbo.[Resultat]";
            try
            {
                db = new DB();
                db.InitPrepare(sql);
                SqlDataReader dr = db.ExecuteSELECT();
                while (dr.Read())
                {
                    Resultat r = new Resultat();
                    r.Id = int.Parse(dr[0].ToString());
                    r.Examen = dr[1].ToString();
                    r.Annee = int.Parse(dr[2].ToString());
                    r.Valeur = float.Parse(dr[3].ToString());
                    r.IdE = new Etablissement();
                    r.IdE.Id = int.Parse(dr[4].ToString());

                    l_resultat.Add(r);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return l_resultat;
        }

        public bool Update(Resultat r)
        {
            throw new NotImplementedException();
        }
    }
}
