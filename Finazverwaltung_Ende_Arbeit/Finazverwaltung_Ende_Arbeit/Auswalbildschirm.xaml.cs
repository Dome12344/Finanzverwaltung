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
using System.Windows.Shapes;

namespace Finazverwaltung_Ende_Arbeit
{
    /// <summary>
    /// Interaktionslogik für Auswalbildschirm.xaml
    /// </summary>
    public partial class Auswalbildschirm : Window
    {
        public Auswalbildschirm()
        {
            InitializeComponent();
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }

        private void budget_berechnen_anzeigen_der_Finanzen_Click(object sender, RoutedEventArgs e)
        {
            Budget_Berchnen_und_anzeigen budget_Berchnen_Und_Anzeigen = new Budget_Berchnen_und_anzeigen();
            this.Close();
            budget_Berchnen_Und_Anzeigen.Show();
        }

        private void budeget_eingeben_neu_verteilen_Click(object sender, RoutedEventArgs e)
        {
            Budgetbildschirm budgetbildschirm = new Budgetbildschirm();
            this.Close();
            budgetbildschirm.Show();
        }

        private void ausgabe_eingeben_Click(object sender, RoutedEventArgs e)
        {
            Ausgabenbildschirm ausgabenbildschirm = new Ausgabenbildschirm();
            this.Close();
            ausgabenbildschirm.Show();
        }

        private void einnahme_eingeben_Click(object sender, RoutedEventArgs e)
        {
            Einhamenbildschirm einhamenbildschirm = new Einhamenbildschirm();
            this.Close();
            einhamenbildschirm.Show();
        }
    }
}
