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
    /// <summary>
    /// Logique d'interaction pour FResultat.xaml
    /// </summary>
    public partial class FResultat : Window
    {
        private IEtablissement ie;
        private IResultat ir;
        public FResultat()
        {
            InitializeComponent();
            loadCombo();
        }

        private void valider_Click(object sender, RoutedEventArgs e)
        {
            Etablissement etablissement = new Etablissement();
            etablissement = (Etablissement)etablissement_cbx.SelectedItem;


            loadCombo();
        }
        private void loadCombo()
        {
            ie = new EtablissementDB();
            etablissement_cbx.ItemsSource = ie.Liste();
        }
        private void loadData()
        {
            
            //ir = new ResultatDB();
            
        }
    }
}
