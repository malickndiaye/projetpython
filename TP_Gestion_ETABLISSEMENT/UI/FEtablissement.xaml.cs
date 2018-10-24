using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TP_Gestion_ETABLISSEMENT.Entities;
using TP_Gestion_ETABLISSEMENT.Model;

namespace TP_Gestion_ETABLISSEMENT.UI
{
    /// <summary
    /// Logique d'interaction pour FEtablissement.xaml
    /// </summary>
    public partial class FEtablissement : Window
    {
        private IEtablissement ie;
        public FEtablissement()
        {
            InitializeComponent();
            connexion_params.Content = User.conn_params;
            loadData();
            //loadTable();
        }
        /*private void loadTable()
        {
            ie = new EtablissementDB();

            //MessageBox.Show(ie.Liste()+"");
            dataGrid.ItemsSource = ie.Liste();
        }*/
        private void valider_Click(object sender, RoutedEventArgs e)
        {
            string nom = nom_txt.Text;
            string ville = ville_txt.Text;
            string telephone = tel_txt.Text;
            int idU = User.id_conn_params;
            Etablissement etablissement = new Etablissement();
            etablissement.NomE = nom;
            etablissement.VilleE = ville;
            etablissement.TelE = telephone;

            etablissement.IdU = new User();
            etablissement.IdU.Id = idU;
            try {
                ie = new EtablissementDB();
                if (ie.Add(etablissement))
                {
                    MessageBox.Show("Données ajoutées");
                }
                else
                {
                    MessageBox.Show("Erreuer : données non ajoutées");
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Erreur ");
            }
            viderChamps();
            loadData();
            //MessageBox.Show(idU + "");
            //loadTable();
        }
        private void loadData()
        {
            ie = new EtablissementDB();
            dataGrid.ItemsSource = ie.Liste();
        }
        private void viderChamps()
        {
            nom_txt.Text = "";
            tel_txt.Text = "";
            ville_txt.Text = "";
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Etablissement et = dataGrid.SelectedItem  as Etablissement;

            MessageBox.Show(et.NomE);
        }
    }
}
