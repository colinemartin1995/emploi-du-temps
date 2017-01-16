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
using ItechSupEDT.DAO;

namespace ItechSupEDT.Ajout_UC
{
    public partial class AjoutSalle : UserControl
    {
        public AjoutSalle()
        {
            InitializeComponent();
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
        private void btn_Valider_Click(object sender, RoutedEventArgs e)
        {
            this.SwipeMessages();
            string nom = this.tb_nomSalle.Text;
            string capacite = this.tb_capaciteSalle.Text;
            try
            {
                Salle promotion = SalleDAO.CreerSalle(nom, capacite);
            }
            catch (Exception error)
            {
                this.tbk_error.Text = "Erreur : " + error.Message;
                this.tbk_error.Visibility = Visibility.Visible;
                return;
            }
            this.tbk_statut.Text = "Salle Ajoutée.";
            this.tbk_statut.Visibility = Visibility.Visible;
        }
    }
}
