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
using ClassPersonale;

namespace InserimentoPersonale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Personale : Window
    {
        private string[] tipologia = new string[] { "Aziendale", "SubFornitore", "Fornitore", "Consulente" };
        private HashSet<string> codiciEsistenti = new HashSet<string>();
        public Personale()
        {
            InitializeComponent();
            LeggiFile();
            txtCodFisc.Focus();

        }

        private void btnPulisci_Click(object sender, RoutedEventArgs e)
        {
            txtCodFisc.Text = "";
            txtCognome.Text = "";
            txtNome.Text = "";
            cmbTipologia.SelectedIndex = -1;
        }
        private void LeggiFile()
        {
            string line;
            StreamReader streamLettura = new StreamReader(Costanti.DIRECTORY + Costanti.FILE);
            do
            {
                line = streamLettura.ReadLine();
                if (line != null)
                {
                    string[] personale = line.Split(';');
                    codiciEsistenti.Add(personale[0]);
                }
            } while (line != null);
            streamLettura.Close();

        }

     

        private void btnEsci_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnInserisci_Click(object sender, RoutedEventArgs e)
        {
            switch (cmbTipologia.SelectedIndex)
            {
                case 0:
                    if (txtCodFisc.Text != "" && txtNome.Text != "" && txtCognome.Text != "" && cmbTipologia.SelectedIndex!=-1)
                    {
                        if (!codiciEsistenti.Contains(txtCodFisc.Text))
                        {
                            PersonaleAziendale pa = new PersonaleAziendale(txtCodFisc.Text, txtNome.Text, txtCognome.Text, cmbTipologia.SelectedItem.ToString());
                            InserimentoPersonaleAziendale formAziendale = new InserimentoPersonaleAziendale(pa);
                            formAziendale.ShowDialog();
                            codiciEsistenti.Add(pa.Codice_Fiscale);
                            txtCodFisc.Text = "";
                            txtCognome.Text = "";
                            txtNome.Text = "";
                            cmbTipologia.SelectedIndex = -1;
                        }
                        else
                        {
                            MessageBox.Show("IL CODICE FISCALE NON PUÒ ESSERE DUPLICATO, RINSERIRE IL CODICE FISCALE","INFORMAZIONE",MessageBoxButton.OK,MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("non sono stati inseriti tutti i dati", "Attezione", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    break;
                case 1:
                    MessageBox.Show("AREA ANCORA IN ELABORAZIONE","INFORMATION", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case 2:
                    MessageBox.Show("AREA ANCORA IN ELABORAZIONE", "INFORMATION", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;

                case 3:
                    if (txtCodFisc.Text != "" && txtNome.Text != "" && txtCognome.Text != "" && cmbTipologia.SelectedIndex != -1)
                    {
                        if (!codiciEsistenti.Contains(txtCodFisc.Text))
                        {
                            PersonaleAziendale pa = new PersonaleAziendale(txtCodFisc.Text, txtNome.Text, txtCognome.Text, cmbTipologia.SelectedItem.ToString());
                            InserimentoPersonaleAziendale formAziendale = new InserimentoPersonaleAziendale(pa);
                            formAziendale.ShowDialog();
                            codiciEsistenti.Add(pa.Codice_Fiscale);
                            txtCodFisc.Text = "";
                            txtCognome.Text = "";
                            txtNome.Text = "";
                            cmbTipologia.SelectedIndex = -1;
                        }
                        else
                        {
                            MessageBox.Show("IL CODICE FISCALE NON PUÒ ESSERE DUPLICATO, RINSERIRE IL CODICE FISCALE", "INFORMAZIONE", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("non sono stati inseriti tutti i dati", "Attezione", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    break;
                   
            }
        }

        private void cmbTipologia_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var tipo in tipologia)
            {
                cmbTipologia.Items.Add(tipo);
            }
        }
    }
}
