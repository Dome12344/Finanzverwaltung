using Finazverwaltung_Ende_Arbeit.model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
    /// Interaktionslogik für Budget_Berchnen_und_anzeigen.xaml
    /// </summary>
    public partial class Budget_Berchnen_und_anzeigen : Window
    {
        private FinazverwaltungContext context = new FinazverwaltungContext();
        private ICollectionView DisplayView;
        public Budget_Berchnen_und_anzeigen()
        {
            InitializeComponent();
            context.Verbleibendesbudget.Load();
            DisplayView = CollectionViewSource.GetDefaultView(context.Verbleibendesbudget.Local.ToObservableCollection());
            DataContext = DisplayView;
        }

        private void zurueck_Click(object sender, RoutedEventArgs e)
        {
            Auswalbildschirm auswalbildschirm = new Auswalbildschirm();
            this.Close();
            auswalbildschirm.Show();
        }

        private void verbleibendesbudget_berechnen_Click(object sender, RoutedEventArgs e)
        {
            decimal Einnahmen = Convert.ToDecimal(Einahmen.Text);
            decimal ausgaben = Convert.ToDecimal(Ausgaben.Text);
            decimal Budget = Convert.ToDecimal(budget.Text);
            decimal verbleibendesbudget = Einnahmen + Budget - ausgaben;
            decimal VB = Convert.ToDecimal(verbleibendesbudget)/100;
            berechnung.Text = Convert.ToString(VB);
        }

        private void verbleibendesbudget_speichern_Click(object sender, RoutedEventArgs e)
        {
            
            context.SaveChanges();
        }
    }
}
