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
    /// Interaction logic for PersonaleAziendale.xaml
    /// </summary>
    public partial class PersonaleAziendaleTable : Window
    {
        public PersonaleAziendaleTable()
        {
            InitializeComponent();
            LeggiFile();
        }
        private void LeggiFile()
        {
            StreamReader streamLettura = new StreamReader(Costanti.DIRECTORY + Costanti.FILE, true);
            int count = 0;
            string line;
            do
            {
                line = streamLettura.ReadLine();
                if (line != null)
                {
                    string[] personale = line.Split(';');
                    foreach (string p in personale)
                        lbMostra.Items.Add(p);

                }
            } while (line != null);

            streamLettura.Close();
        }

        private void btnIndietro_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEsci_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
        }
    }
}
