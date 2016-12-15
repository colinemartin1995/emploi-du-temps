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

namespace ItechSupEDT.Ajout_UC
{
    /// <summary>
    /// Interaction logic for AjoutFormateur.xaml
    /// </summary>
    public partial class AjoutFormateur : UserControl
    {
        public AjoutFormateur(List<Matiere> _lstMatiere)
        {
            InitializeComponent();
            List<Nameable> lstNameable = new List<Nameable>();
            foreach (Matiere mat in _lstMatiere)
            {
                lstNameable.Add((Nameable)mat);
            }
            MutliSelectPickList multiSelect = new MutliSelectPickList(lstNameable);
            this.MultiSelect.Content = multiSelect;
        }

        private void btn_ajoutFormation_Click(object sender, RoutedEventArgs e)
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
            List<Nameable> lstMatieresNameable = ((MutliSelectPickList)(this.MultiSelect.Content)).GetSelectedObjects();
            List<Matiere> lstMatieres = new List<Matiere>();
            foreach (Nameable mat in lstMatieresNameable)
            {
                lstMatieres.Add((Matiere)mat);
            }
            if (lstMatieres.Count > 0)
            {
                String nom = this.tb_nomFormateur.Text;
                String prenom = this.tb_prenomFormateur.Text;
                String mail = this.tb_mailFormateur.Text;
            }
            else
            {
                this.tbk_error.Text = "Veuillez sélectionner au moins une matière.";
                this.tbk_error.Visibility = Visibility.Visible;
                return;
            }
        }
    }
}
