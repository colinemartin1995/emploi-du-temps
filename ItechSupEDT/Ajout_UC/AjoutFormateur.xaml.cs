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

namespace ItechSupEDT.Ajout_UC
{
    /// <summary>
    /// Interaction logic for AjoutFormateur.xaml
    /// </summary>
    public partial class AjoutFormateur : UserControl
    {
        public AjoutFormateur(List<Nameable> _lstMatiere)
        {
            InitializeComponent();
            MutliSelectPickList multiSelect = new MutliSelectPickList(_lstMatiere);
            this.MultiSelect.Content = multiSelect;
        }
    }
}
