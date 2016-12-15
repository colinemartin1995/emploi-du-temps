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
using System.Collections.ObjectModel;

namespace ItechSupEDT.Ajout_UC
{
    /// <summary>
    /// Logique d'interaction pour MutliSelectPickList.xaml
    /// </summary>
    public partial class MutliSelectPickList : UserControl 
    {
        private ObservableCollection<String> objectList;
        private ObservableCollection<String> selectedList;
        private List<Nameable> maList;
        private Dictionary<String, Nameable> nameToObject;

        public List<Nameable> MaList
        {
            get { return maList; }
            set { maList = value; }
        }
        public MutliSelectPickList(List<Nameable> _maList)
        {
            InitializeComponent();
            nameToObject = new Dictionary<String, Nameable>();
            objectList = new ObservableCollection<String>();
            selectedList = new ObservableCollection<String>();
            this.MaList = _maList;
            foreach(Nameable objet in this.MaList)
            {
                this.objectList.Add(objet.getNom());
                this.nameToObject.Add(objet.getNom(), objet);
            }
            this.SetListview();
        }
        private void SetListview()
        {
            lv_listeObject.ItemsSource = this.objectList;
            lv_selectedObject.ItemsSource = this.selectedList;
        }
        public List<Nameable> GetSelectedObjects()
        {
            List<Nameable> lstRetour = new List<Nameable>();
            foreach (String name in this.selectedList)
            {
                lstRetour.Add(this.nameToObject[name]);
            }

            return lstRetour;
        }
        private void btn_push_Click(object sender, RoutedEventArgs e)
        {
            if(lv_listeObject.SelectedItem != null)
            {
                selectedList.Add(lv_listeObject.SelectedItem.ToString());
                objectList.Remove(lv_listeObject.SelectedItem.ToString());
                this.SetListview();
            }
        }
        private void btn_pull_Click(object sender, RoutedEventArgs e)
        {
            if (lv_selectedObject.SelectedItem != null)
            {
                objectList.Add(lv_selectedObject.SelectedItem.ToString());
                selectedList.Remove(lv_selectedObject.SelectedItem.ToString());
                this.SetListview();
            }
        }
    }
}
