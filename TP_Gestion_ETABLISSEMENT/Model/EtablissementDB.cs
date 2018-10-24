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
    public class EtablissementDB : IEtablissement
    {
        private DB db;
        private bool ok;
        private SqlDataReader dr;

        public bool Add(Etablissement e)
        {
            string sql = "INSERT INTO etablissement(NomE, VilleE, TelE, idU) VALUES(@NomE, @VilleE, @TelE, @idU)";
            ok = false;
            try
            {
                db = new DB();

                db.InitPrepare(sql);

                db.GetCmd().Parameters.Add("@NomE", SqlDbType.VarChar, 255);
                db.GetCmd().Parameters.Add("@VilleE", SqlDbType.VarChar, 150);
                db.GetCmd().Parameters.Add("@TelE", SqlDbType.VarChar, 15);
                db.GetCmd().Parameters.Add("@idU", SqlDbType.Int);

                db.GetCmd().Parameters["@NomE"].Value = e.NomE;
                db.GetCmd().Parameters["@VilleE"].Value = e.VilleE;
                db.GetCmd().Parameters["@TelE"].Value = e.TelE;
                db.GetCmd().Parameters["@idU"].Value = e.IdU.Id;

                if(db.ExecuteMAJ() != 0)
                {
                    ok = true;
                }
            }
            catch (Exception ex)
            {
                ok = false;
                MessageBox.Show(ex.Message.ToString());
            }
            return ok;
        }

        public bool Delete(int IdE)
        {
            string sql = "DELETE FROM etablissement WHERE Id = @Id";
            ok = false;
            try
            {
                db = new DB();
                db.InitPrepare(sql);
                db.GetCmd().Parameters.Add("@Id", SqlDbType.Int);
                db.GetCmd().Parameters["@Id"].Value = IdE;
                if(db.ExecuteMAJ() != 0)
                {
                    ok = true;
                    //MessageBox.Show(db.GetCmd().CommandText);
                }
            }
            catch (Exception ex)
            {
                ok = false;
                MessageBox.Show(ex.Message.ToString());
            }
            return ok;
        }
        public bool Update(Etablissement e)
        {
            string sql = "UPDATE etablissement SET NomE =  @NomE, "+
                " VilleE = @VilleE, TelE = @TelE, idU = @idU WHERE Id = @Id";
            ok = false;
            try
            {
                db = new DB();

                db.InitPrepare(sql);

                db.GetCmd().Parameters.Add("@Id", SqlDbType.Int);
                db.GetCmd().Parameters.Add("@NomE", SqlDbType.VarChar, 255);
                db.GetCmd().Parameters.Add("@VilleE", SqlDbType.VarChar, 150);
                db.GetCmd().Parameters.Add("@TelE", SqlDbType.VarChar, 15);
                db.GetCmd().Parameters.Add("@idU", SqlDbType.Int);

                db.GetCmd().Parameters["@Id"].Value = e.Id;
                db.GetCmd().Parameters["@NomE"].Value = e.NomE;
                db.GetCmd().Parameters["@VilleE"].Value = e.VilleE;
                db.GetCmd().Parameters["@TelE"].Value = e.TelE;
                db.GetCmd().Parameters["@idU"].Value = e.IdU.Id;

                if (db.ExecuteMAJ() != 0)
                {
                    ok = true;
                }
            }
            catch (Exception ex)
            {
                ok = false;
                MessageBox.Show(ex.Message.ToString());
            }
            return ok;
        }
        public List<Resultat> GetResultatsByEtablissement(int IdE)
        {
            List<Resultat> l_resultat = new List<Resultat>();
            string sql = "SELECT * FROM resultat WHERE IdE = @IdE";
            try
            {
                db = new DB();
                db.InitPrepare(sql);
                db.GetCmd().Parameters.Add("@IdE", SqlDbType.Int);
                db.GetCmd().Parameters["@IdE"].Value = IdE;
                dr = db.ExecuteSELECT();
                while (dr.Read())
                {
                    Resultat r = new Resultat();
                    r.Id = int.Parse(dr[0].ToString());
                    r.Examen = dr[1].ToString();
                    r.Annee = int.Parse(dr[2].ToString());
                    r.Valeur = float.Parse(dr[3].ToString());

                    l_resultat.Add(r);
                }
                dr.Close();
                db.CloseConnexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return l_resultat;
        }

        public Resultat GetResultatsByEtablissementAndYear(int IdE, int annee)
        {
            Resultat r = null;
            string sql = "SELECT * FROM resultat WHERE IdE = @IdE AND Annee = @Annee";
            try
            {
                db = new DB();
                db.InitPrepare(sql);

                db.GetCmd().Parameters.Add("@IdE", SqlDbType.Int);
                db.GetCmd().Parameters.Add("@Annee", SqlDbType.Int);

                db.GetCmd().Parameters["@IdE"].Value = IdE;
                db.GetCmd().Parameters["@Annee"].Value = annee;
                dr = db.ExecuteSELECT();
                while (dr.Read())
                {
                    r = new Resultat();
                    r.Id = int.Parse(dr[0].ToString());
                    r.Examen = dr[1].ToString();
                    r.Annee = int.Parse(dr[2].ToString());
                    r.Valeur = float.Parse(dr[3].ToString());
                }
                dr.Close();
                db.CloseConnexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return r;
        }

        public List<Etablissement> Liste()
        {
            List<Etablissement> l_etablissement = new List<Etablissement>();
            string sql = "SELECT * FROM etablissement";
            try
            {
                db = new DB();
                db.InitPrepare(sql);
                dr = db.ExecuteSELECT();
                while (dr.Read())
                {
                    Etablissement e = new Etablissement();
                    e.Id = int.Parse(dr[0].ToString());
                    e.NomE = dr[1].ToString();
                    e.VilleE = dr[2].ToString();
                    e.TelE = dr[3].ToString();
                    //Gestion de l'utilisateur
                    e.IdU = (new UserDB()).GetUserById(int.Parse(dr[4].ToString()));

                    l_etablissement.Add(e);
                }
                dr.Close();
                db.CloseConnexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return l_etablissement;
        }

        
    }
}
