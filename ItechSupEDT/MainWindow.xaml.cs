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
            AjoutMatiere ajoutMatiere = new AjoutMatiere();
            this.Ajout.Content = ajoutMatiere;
        }

        private void mi_ajout_promotion_Click(object sender, RoutedEventArgs e)
        {
            List<MultiSelectedObject> lstEleves = new List<MultiSelectedObject>();
            AjoutPromotion ajoutPromotion = new AjoutPromotion(new List<Formation>(), lstEleves);
            this.Ajout.Content = ajoutPromotion;
        }

        private void mi_ajout_formateur_Click(object sender, RoutedEventArgs e)
        {
            List<MultiSelectedObject> lstMatiere = new List<MultiSelectedObject>();
            AjoutFormateur ajoutFormateur = new AjoutFormateur(lstMatiere);
            this.Ajout.Content = ajoutFormateur;
        }

        private void mi_afficher_formation_Click(object sender, RoutedEventArgs e)
        {
            this.error_message.Text = "";
            String nom = "";
            float nbHeures = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SELECT Nom, NbHeuresTotal FROM Formation WHERE Id = 1;";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = Outils.ConnexionBase.GetInstance().Conn;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nom = reader["Nom"].ToString();
                    nbHeures = float.Parse(reader["NbHeuresTotal"].ToString());
                }
                reader.Close();
            }
            catch (Exception error)
            {
                this.error_message.Text = error.Message;
                return;
            }
            Formation formation = new Modele.Formation(nom, nbHeures);
            Ajout_UC.AjoutFormation ajoutFormation = new Ajout_UC.AjoutFormation(formation);
            this.Ajout.Content = ajoutFormation;
        }

        private void mi_afficher_matiere_Click(object sender, RoutedEventArgs e)
        {
            this.error_message.Text = "";
            String nom = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SELECT Nom FROM Matiere WHERE Id = 1;";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = Outils.ConnexionBase.GetInstance().Conn;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nom = reader["Nom"].ToString();
                }
                reader.Close();
            }
            catch (Exception error)
            {
                this.error_message.Text = error.Message;
                return;
            }
            Matiere matiere = new Matiere(nom);
            Ajout_UC.AjoutMatiere ajoutMatiere = new Ajout_UC.AjoutMatiere(matiere);
            this.Ajout.Content = ajoutMatiere;
        }
    }
}
