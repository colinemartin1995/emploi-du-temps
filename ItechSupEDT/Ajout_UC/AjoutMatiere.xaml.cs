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
    /// Interaction logic for AjoutMatiere.xaml
    /// </summary>
    public partial class AjoutMatiere : UserControl
    {
        public AjoutMatiere(List<Formation> _lstFormation)
        {
            InitializeComponent();
            List<Nameable> lstNameable = new List<Nameable>();
            foreach (Formation form in _lstFormation)
            {
                lstNameable.Add((Nameable)form);
            }
            MutliSelectPickList multiSelect = new MutliSelectPickList(lstNameable);
            this.MultiSelect.Content = multiSelect;
        }

        public AjoutMatiere(Matiere _matiere, List<Formation> _lstFormation)
        {
            InitializeComponent();
            this.tb_nomMatiere.Text = _matiere.Nom;
            List<Nameable> lstNameable = new List<Nameable>();
            foreach (Formation form in _lstFormation)
            {
                lstNameable.Add((Nameable)form);
            }
            MutliSelectPickList multiSelect = new MutliSelectPickList(lstNameable);
            this.MultiSelect.Content = multiSelect;
        }

        private void btn_valider_Click(object sender, RoutedEventArgs e)
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
            List<Formation> lstSelectedFormation = new List<Formation>();
            foreach (Nameable nam in ((MutliSelectPickList)this.MultiSelect.Content).GetSelectedObjects())
            {
                lstSelectedFormation.Add((Formation)nam);
            }
            try
            {
                Matiere formation = MatiereDAO.CreerMatiere(this.tb_nomMatiere.Text, lstSelectedFormation);
            }
            catch (Exception error)
            {
                this.tbk_error.Text = "Erreur : " + error.Message;
                this.tbk_error.Visibility = Visibility.Visible;
                return;
            }
            this.tbk_statut.Text = "Matière Ajoutée.";
            this.tbk_statut.Visibility = Visibility.Visible;
        }
    }
}
