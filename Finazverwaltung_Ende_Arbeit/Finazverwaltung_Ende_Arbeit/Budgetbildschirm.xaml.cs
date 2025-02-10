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
    /// Interaktionslogik für Budgetbildschirm.xaml
    /// </summary>
    public partial class Budgetbildschirm : Window
    {
        public Budgetbildschirm()
        {
            InitializeComponent();
        }

        private void budget_uebermitteln_Click(object sender, RoutedEventArgs e)
        {

        }

        private void budget_aenderung_uebermitteln_Click(object sender, RoutedEventArgs e)
        {

        }

        private void zurueck_Click(object sender, RoutedEventArgs e)
        {
            Auswalbildschirm auswalbildschirm = new Auswalbildschirm();
            this.Close();
            auswalbildschirm.Show();
        }
    }
}
