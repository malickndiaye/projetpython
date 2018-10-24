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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TP_Gestion_ETABLISSEMENT.Entities;
using TP_Gestion_ETABLISSEMENT.Model;
using TP_Gestion_ETABLISSEMENT.UI;

namespace TP_Gestion_ETABLISSEMENT
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void connexion_Click(object sender, RoutedEventArgs e)
        {
            if (login_txt.Text.Trim().Equals("") || password_txt.Password.ToString().Equals(""))
            {
                MessageBox.Show("Veuillez saisir tous les champs SVP !!!");
            }
            else
            {
                IUser iu = new UserDB();
                User u = iu.GetLogin(login_txt.Text, password_txt.Password);
                if (u != null)
                {
                    User.id_conn_params = u.Id;
                    User.conn_params = "Bienvenue " + u.Prenom + "  " + u.Nom;

                    this.Hide();
                    //FEtablissement et = new FEtablissement();
                    //et.Show();

                    FResultat fr = new FResultat();
                    fr.Show();
                }
                else
                {
                    MessageBox.Show("Login ou mot de passe incorrect !!!!!");
                }
            }
        }
    }
}
