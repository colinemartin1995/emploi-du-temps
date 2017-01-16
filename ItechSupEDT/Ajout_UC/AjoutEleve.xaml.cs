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
    /// <summary>
    /// Interaction logic for AjoutEleve.xaml
    /// </summary>
    public partial class AjoutEleve : UserControl
    {
        private Dictionary<String, Promotion> dicoPromotions;
        public Dictionary<String, Promotion> icoPromotions
        {
            get { return this.dicoPromotions; }
            set { this.dicoPromotions = value; }
        }
        public AjoutEleve(Eleve eleve)
        {
            String nom = eleve.Nom;
            String prenom = eleve.Prenom;
            String mail = eleve.Mail;
        }
        public AjoutEleve(List<Promotion> _lstPromotion)
        {
            InitializeComponent();
            this.dicoPromotions = new Dictionary<string, Promotion>();
            if (_lstPromotion.Count > 0)
            {
                foreach (Promotion formation in _lstPromotion)
                {
                    this.dicoPromotions.Add(formation.Nom, formation);
                }
                this.cb_lstPromotion.ItemsSource = this.dicoPromotions.Keys;
            }
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
        private void btn_valider_Click(object sender, RoutedEventArgs e)
        {
            this.SwipeMessages();
            String nom = tb_nomEleve.Text;
            String prenom = tb_prenomEleve.Text;
            String mail = tb_mailEleve.Text;
            Promotion prom = null;
            if (this.cb_lstPromotion.SelectedItem != null)
            {
                prom = this.dicoPromotions[(String)cb_lstPromotion.SelectedItem];
            }
            try
            {
                Eleve eleve = EleveDAO.CreerEleve(nom, prenom, mail, prom);
            }
            catch (Exception error)
            {
                this.tbk_error.Text = "Erreur : " + error.Message;
                this.tbk_error.Visibility = Visibility.Visible;
                return;
            }
            this.tbk_statut.Text = "Eleve Ajouté.";
            this.tbk_statut.Visibility = Visibility.Visible;
        }
    }
}
