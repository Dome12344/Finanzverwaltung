using Microsoft.Data.SqlClient;
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
    /// Interaktionslogik für Einhamenbildschirm.xaml
    /// </summary>
    public partial class Einhamenbildschirm : Window
    {
        public Einhamenbildschirm()
        {
            InitializeComponent();
        }

        private void einnahmen_uebermitteln_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Finanzverwaltung;Integrated Security = True");
                con.Open();
                string add_data = "INSERT INTO [dbo].[Einnahmen] VALUES (@Einnahmen)";
                SqlCommand cmd = new SqlCommand(add_data, con);
                cmd.Parameters.AddWithValue("@Einnahmen", einnahme.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                einnahme.Text = "";


                

            }
            catch
            {

            }
        }

        private void zurueck_Click(object sender, RoutedEventArgs e)
        {
            Auswalbildschirm auswalbildschirm = new Auswalbildschirm();
            this.Close();
            auswalbildschirm.Show();
        }
    }
}
