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
        public AjoutPromotion(List<Formation> _lstFormations, List<MultiSelectedObject> _lstEleve)
        {
            InitializeComponent();

            this.LstFormations = new Dictionary<string, Formation>();
            if (_lstFormations.Count > 0)
            {
                foreach (Formation formation in _lstFormations)
                {
                    this.LstFormations.Add(formation.Nom, formation);
                }
                this.cb_lstFormations.ItemsSource = this.LstFormations.Keys;
                this.cb_lstFormations.SelectedIndex = 0;
            }
            
            MutliSelectPickList multiSelect = new MutliSelectPickList(this.getListEleves());
            this.MultiSelect.Content = multiSelect;
        }

        public List<MultiSelectedObject> getListEleves()
        {
            List<MultiSelectedObject> lstResult = new List<MultiSelectedObject>();
            String nom = "";
            String prenom = "";
            String mail = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SELECT * FROM Eleve;";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = Outils.ConnexionBase.GetInstance().Conn;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nom = reader["Nom"].ToString();
                    prenom = reader["prenom"].ToString();
                    mail = reader["mail"].ToString();
                    lstResult.Add((MultiSelectedObject)new Eleve(nom, prenom, mail));
                }
            }
            catch (Exception error)
            {
                return null;
            }
            return lstResult;
        }
    }
}
