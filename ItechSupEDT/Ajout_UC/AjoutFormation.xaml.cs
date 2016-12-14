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

        private void btn_ajoutFormation_Click(object sender, RoutedEventArgs e)
        {
            String nom = tb_nomFormation.Text;
            String nbHeures = tb_dureeFormation.Text;
            try
            {
                float duree = Single.Parse(nbHeures);
                try
                {
                    Formation formation = new Formation(nom, duree);
                }
                catch (Formation.FormationException error)
                {
                    tbk_errorMessage.Text = error.Message;
                }
                try
                {
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "INSERT INTO Formation (Nom, NbHeuresTotal) VALUES (\'" + nom + "\'," + duree + ");";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = Outils.ConnexionBase.GetInstance().Conn;
                    tbk_errorMessage.Text = cmd.CommandText;
                    cmd.ExecuteReader();
                }
                catch (Exception error)
                {
                    tbk_errorMessage.Text += error.Message;
                }
            }
            catch(Exception)
            {
                tbk_errorMessage.Text = "Désolé, une erreur est survenu lors de l'ajout de la formation, veuillez vérifier les informations renseignées et recommencer.";
            }
            
        }
    }
}
