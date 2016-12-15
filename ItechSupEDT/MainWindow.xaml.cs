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
            AjoutMatiere ajoutMatiere = new AjoutMatiere(GetFormations());
            this.Ajout.Content = ajoutMatiere;
        }

        private void mi_ajout_promotion_Click(object sender, RoutedEventArgs e)
        {
            AjoutPromotion ajoutPromotion = new AjoutPromotion(GetFormations());
            this.Ajout.Content = ajoutPromotion;
        }
        private void mi_ajout_formateur_Click(object sender, RoutedEventArgs e)
        {
            //AjoutFormateur ajoutFormateur = new AjoutFormateur(GetMatieres());
            //this.Ajout.Content = ajoutFormateur;
        }

        private List<Formation> GetFormations()
        {
            List<Formation> lstFormations = new List<Formation>();
            this.error_message.Text = "";
            String nom = "";
            int id;
            float nbHeures = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SELECT Id, Nom, NbHeuresTotal FROM Formation;";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = Outils.ConnexionBase.GetInstance().Conn;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id = int.Parse(reader["Id"].ToString());
                    nom = reader["Nom"].ToString();
                    nbHeures = float.Parse(reader["NbHeuresTotal"].ToString());
                    lstFormations.Add(new Formation(id, nom, nbHeures));
                }
                reader.Close();
            }
            catch (Exception error)
            {
                this.error_message.Text = error.Message;
                return null;
            }
            return lstFormations;
        }

        private List<Promotion> GetPromotions()
        {
            // TODO Récuperer les promotions (sans l'id formation)
            // Nouveau constructeur dans promotion qui ne prend pas de formation
            // Envoyer cette liste de promotions dans l'ajout d'élèves et finir l'ajout d'élèves
            List<Promotion> lstFormations = new List<Promotion>();
            this.error_message.Text = "";
            String nom = "";
            DateTime dateDebut;
            DateTime dateFin;
            int id;
            float nbHeures = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SELECT Id, Nom, NbHeuresTotal FROM Formation;";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = Outils.ConnexionBase.GetInstance().Conn;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id = int.Parse(reader["Id"].ToString());
                    nom = reader["Nom"].ToString();
                    nbHeures = float.Parse(reader["NbHeuresTotal"].ToString());
                }
                reader.Close();
            }
            catch (Exception error)
            {
                this.error_message.Text = error.Message;
                return null;
            }
            return lstFormations;
        }

        //private List<Matiere> GetMatieres()
        //{
        //    List<Matiere> lstMatieres = new List<Matiere>();
        //    this.error_message.Text = "";
        //    String nom = "";
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        SqlDataReader reader;

        //        cmd.CommandText = "SELECT Nom FROM Matiere;";
        //        cmd.CommandType = CommandType.Text;
        //        cmd.Connection = Outils.ConnexionBase.GetInstance().Conn;
        //        reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            nom = reader["Nom"].ToString();
        //            lstMatieres.Add(new Matiere(nom));
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception error)
        //    {
        //        this.error_message.Text = error.Message;
        //        return null;
        //    }
        //    return lstMatieres;
        //}

        private void mi_afficher_formation_Click(object sender, RoutedEventArgs e)
        {
            //this.error_message.Text = "";
            //String nom = "";
            //float nbHeures = 0;
            //try
            //{
            //    SqlCommand cmd = new SqlCommand();
            //    SqlDataReader reader;

            //    cmd.CommandText = "SELECT Nom, NbHeuresTotal FROM Formation WHERE Id = 1;";
            //    cmd.CommandType = CommandType.Text;
            //    cmd.Connection = Outils.ConnexionBase.GetInstance().Conn;
            //    reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        nom = reader["Nom"].ToString();
            //        nbHeures = float.Parse(reader["NbHeuresTotal"].ToString());
            //    }
            //    reader.Close();
            //}
            //catch (Exception error)
            //{
            //    this.error_message.Text = error.Message;
            //    return;
            //}
            //Formation formation = new Modele.Formation(nom, nbHeures);
            //Ajout_UC.AjoutFormation ajoutFormation = new Ajout_UC.AjoutFormation(formation);
            //this.Ajout.Content = ajoutFormation;
        }

        private void mi_afficher_matiere_Click(object sender, RoutedEventArgs e)
        {
            //this.error_message.Text = "";
            //String nom = "";
            //try
            //{
            //    SqlCommand cmd = new SqlCommand();
            //    SqlDataReader reader;

            //    cmd.CommandText = "SELECT Nom FROM Matiere WHERE Id = 1;";
            //    cmd.CommandType = CommandType.Text;
            //    cmd.Connection = Outils.ConnexionBase.GetInstance().Conn;
            //    reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        nom = reader["Nom"].ToString();
            //    }
            //    reader.Close();
            //}
            //catch (Exception error)
            //{
            //    this.error_message.Text = error.Message;
            //    return;
            //}
            //Matiere matiere = new Matiere(nom);
            //Ajout_UC.AjoutMatiere ajoutMatiere = new Ajout_UC.AjoutMatiere(matiere);
            //this.Ajout.Content = ajoutMatiere;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AjoutSalle ajoutSalle = new AjoutSalle();
            this.Ajout.Content = ajoutSalle;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            AjoutEleve ajoutEleve = new AjoutEleve();
            this.Ajout.Content = ajoutEleve;
        }
    }
}
