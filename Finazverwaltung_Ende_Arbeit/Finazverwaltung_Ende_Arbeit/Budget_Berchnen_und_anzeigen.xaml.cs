﻿using System;
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
    /// Interaktionslogik für Budget_Berchnen_und_anzeigen.xaml
    /// </summary>
    public partial class Budget_Berchnen_und_anzeigen : Window
    {
        public Budget_Berchnen_und_anzeigen()
        {
            InitializeComponent();
        }

        private void zurueck_Click(object sender, RoutedEventArgs e)
        {
            Auswalbildschirm auswalbildschirm = new Auswalbildschirm();
            this.Close();
            auswalbildschirm.Show();
        }

        private void budegt_aenderung_speichern_Click(object sender, RoutedEventArgs e)
        {

        }

        private void budget_berechnen_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
