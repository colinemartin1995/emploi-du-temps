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
using ItechSupEDT.Modele;
using System.Data.SqlClient;
using System.Data;
using ItechSupEDT.DAO;

namespace ItechSupEDT.Ajout_UC
{
    /// <summary>
    /// Interaction logic for AjoutFormation.xaml
    /// </summary>
    public partial class AjoutFormation : UserControl
    {
        public AjoutFormation()
        {
            InitializeComponent();
        }

        public AjoutFormation(Formation _formation)
        {
            InitializeComponent();
            tb_nomFormation.Text = _formation.Nom;
            tb_dureeFormation.Text = _formation.NbHeuresTotal.ToString();
        }
        private void SwipeMessages()
        {
            if (this.tbk_error.Visibility == Visibility.Visible)
            {
                this.tbk_error.Text = "";
                this.tbk_error.Visibility = Visibility.Collapsed;
            }
            if (this.tbk_statut.Visibility == Visibility.Visible)
            {
                this.tbk_statut.Text = "";
                this.tbk_statut.Visibility = Visibility.Collapsed;
            }
        }
        private void btn_ajoutFormation_Click(object sender, RoutedEventArgs e)
        {
            this.SwipeMessages();
            try
            {
                Formation formation = FormationDAO.CreerFormation(tb_nomFormation.Text, tb_dureeFormation.Text);
            }
            catch(Exception error)
            {
                this.tbk_error.Text = "Erreur : " + error.Message + ".";
                this.tbk_error.Visibility = Visibility.Visible;
            }
            this.tbk_statut.Text = "Formation Ajoutée.";
            this.tbk_statut.Visibility = Visibility.Visible;
        }
    }
}
