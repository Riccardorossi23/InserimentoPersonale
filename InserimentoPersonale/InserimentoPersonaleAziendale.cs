using ClassPersonale;
using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class InserimentoPersonaleAziendale : Window
    {
        private string[] qualifiche = new string[] { "Dirigente", "Quadro", "Amministrativo", "Operaio" };
        public PersonaleAziendale pa;
        public InserimentoPersonaleAziendale(PersonaleAziendale pa)
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
            try
            {
                if(cmbQualifica.SelectedIndex==-1 && txtArea.Text=="" )
                {
                    MessageBox.Show("Inserire i dati", "ATTENZIONE", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    pa.Qualifica = cmbQualifica.SelectedItem.ToString();
                    pa.Area = txtArea.Text;
                    lbRiepilogo.Items.Add(pa.ToString());
                    StreamWriter sw = new StreamWriter(Costanti.DIRECTORY + Costanti.FILE, true);
                    string tabella = $"{pa.Codice_Fiscale};:{pa.Nome};{pa.Cognome};{pa.Tipologia};{pa.Qualifica};{pa.Area}";
                    sw.WriteLine(tabella);
                    sw.Flush();
                    sw.Close();
                    cmbQualifica.IsEnabled = false;
                    txtArea.IsEnabled = false;
                    lbRiepilogo.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void btnNuovoInserimento_Click(object sender, RoutedEventArgs e)
        {


            if (lbRiepilogo.Items.Count == 0)
            {
                MessageBox.Show("Inserire qualifica e area per creare la persona aziendale!", "ERRORE", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
            else
            {
                this.Close();
            }
               
        }

        private void btnMostraFile_Click(object sender, RoutedEventArgs e)
        {
            new PersonaleAziendaleTable().ShowDialog();
        }
    }
       
    
}
