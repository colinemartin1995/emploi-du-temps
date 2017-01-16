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
using ItechSupEDT.Ajout_UC;
using ItechSupEDT.Modele;
using System.Data.SqlClient;
using System.Data;
using ItechSupEDT.DAO;

namespace ItechSupEDT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
        }
		
        private void mi_ajout_formation_Click(object sender, RoutedEventArgs e)
        {
            Ajout_UC.AjoutFormation ajoutFormation = new Ajout_UC.AjoutFormation();
            this.Ajout.Content = ajoutFormation;
		}
		
        private void mi_ajout_matiere_Click(object sender, RoutedEventArgs e)
        {
            AjoutMatiere ajoutMatiere = new AjoutMatiere(FormationDAO.GetAll());
            this.Ajout.Content = ajoutMatiere;
        }

        private void mi_ajout_promotion_Click(object sender, RoutedEventArgs e)
        {
            AjoutPromotion ajoutPromotion = new AjoutPromotion(FormationDAO.GetAll());
            this.Ajout.Content = ajoutPromotion;
        }
        private void mi_ajout_formateur_Click(object sender, RoutedEventArgs e)
        {
            AjoutFormateur ajoutFormateur = new AjoutFormateur(MatiereDAO.GetAll());
            this.Ajout.Content = ajoutFormateur;
        }

        private void mi_ajout_salle_Click(object sender, RoutedEventArgs e)
        {
            AjoutSalle ajoutSalle = new AjoutSalle();
            this.Ajout.Content = ajoutSalle;
        }

        private void mi_ajout_eleve_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AjoutEleve ajoutEleve = new AjoutEleve(PromotionDAO.GetAll());
                this.Ajout.Content = ajoutEleve;
            }
            catch (Exception error)
            {
                this.error_message.Text = error.Message;
            }
        }
    }
}
