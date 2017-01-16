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
using ItechSupEDT.Ajout_UC;
using System.Data.SqlClient;
using System.Data;
using ItechSupEDT.DAO;

namespace ItechSupEDT.Ajout_UC
{
    /// <summary>
    /// Interaction logic for AjoutPromotion.xaml
    /// </summary>
    public partial class AjoutPromotion : UserControl
    {
        private Dictionary<String, Formation> lstFormations;
        public Dictionary<String, Formation> LstFormations
        {
            get { return this.lstFormations; }
            set { this.lstFormations = value; }
        }
        public AjoutPromotion(List<Formation> _lstFormations)
        {
            InitializeComponent();
            this.dp_dateDebut.SelectedDate = DateTime.Today;
            this.dp_dateFin.SelectedDate = DateTime.Today.AddYears(1);
            this.LstFormations = new Dictionary<string, Formation>();
            if (_lstFormations.Count > 0)
            {
                foreach (Formation formation in _lstFormations)
                {
                    this.LstFormations.Add(formation.Nom, formation);
                }
                this.cb_lstFormations.ItemsSource = this.LstFormations.Keys;
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
        private void btn_Valider_Click(object sender, RoutedEventArgs e)
        {
            this.SwipeMessages();
            string nom = this.tb_nom.Text;
            DateTime _dateDebut = this.dp_dateDebut.SelectedDate.GetValueOrDefault();
            DateTime _dateFin = this.dp_dateFin.SelectedDate.GetValueOrDefault();
            Formation _formation = null;
            if (this.cb_lstFormations.SelectedItem != null)
            {
                _formation = LstFormations[(String)(this.cb_lstFormations.SelectedItem)];
            }
            try
            {
                Promotion promotion = PromotionDAO.CreerPromotion(nom, _dateDebut, _dateFin, _formation);
            }
            catch (Exception error)
            {
                this.tbk_error.Text = "Erreur : " + error.Message;
                this.tbk_error.Visibility = Visibility.Visible;
                return;
            }
            this.tbk_statut.Text = "Promotion Ajoutée.";
            this.tbk_statut.Visibility = Visibility.Visible;
        }
    }
}
