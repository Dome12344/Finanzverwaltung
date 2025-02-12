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
    /// Interaktionslogik für Ausgabenbildschirm.xaml
    /// </summary>
    public partial class Ausgabenbildschirm : Window
    {
        public Ausgabenbildschirm()
        {
            InitializeComponent();
        }

        private void zurueck_Click(object sender, RoutedEventArgs e)
        {
            Auswalbildschirm auswalbildschirm = new Auswalbildschirm();
            this.Close();
            auswalbildschirm.Show();
        }

        private void ausgaben_uebermitteln_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Finanzverwaltung;Integrated Security = True");
            con.Open();
            string add_data = "INSERT INTO [dbo].[Ausgaben] VALUES (@Ausgaben)";
            SqlCommand cmd = new SqlCommand(add_data, con);
            cmd.Parameters.AddWithValue("@Ausgaben", ausgaben.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            ausgaben.Text = "";
        }
    }
}
