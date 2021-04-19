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

namespace InserimentoPersonale
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private string[] qualifiche = new string[] { "Dirigente", "Quadro", "Ammministrativo", };
        public PersonaleAziendale pa;
        public Page1(PersonaleAziendale pa)
        {
            this.pa = pa;
        
       
            InitializeComponent();
        }
        private void cmbQualifica_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string s in qualifiche)
                cmbQualifica.Items.Add(s);
        }

        private void btnInserisci_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
