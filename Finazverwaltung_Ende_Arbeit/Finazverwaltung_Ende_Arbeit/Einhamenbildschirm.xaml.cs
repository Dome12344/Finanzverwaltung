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
            string VB = "";


            try
            {
                string pr_data = "SELECT Verbleibudgetnummer FROM [dbo].[Verbleibendesbudget] WHERE Verbleibudgetnummer=@Verbleibudgetnummer";
                SqlConnection con3 = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Finanzverwaltung;Integrated Security=True");
                con3.Open();
                SqlCommand cmd3 = new SqlCommand(pr_data, con3);
                cmd3.Parameters.AddWithValue("@Verbleibudgetnummer", Verbleibudgetnummer.Text);


                SqlDataReader reader = cmd3.ExecuteReader();
                if (reader.Read())
                {
                    VB = reader["Verbleibudgetnummer"].ToString();
                }
                reader.Close();
                con3.Close();
            }
            catch
            {
                MessageBox.Show("Es Besteht kein Verbindung zu  SQL");
            }
            if (Verbleibudgetnummer.Text == VB)
            {

                try
                {
                    SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Finanzverwaltung;Integrated Security = True");
                    con.Open();
                    string add_data = "INSERT INTO [dbo].[Einnahmen] VALUES (@Einnahmen)";
                    SqlCommand cmd = new SqlCommand(add_data, con);
                    cmd.Parameters.AddWithValue("@Einnahmen", Convert.ToDecimal(einnahme.Text));
                    cmd.ExecuteNonQuery();
                    con.Close();

                   
                    con.Open();
                    string upd_data = ("Update [dbo].[Verbleibendesbudget] set Einnahmen = @Einnahmenup Where Verbleibudgetnummer = @Verbleibudgetnummerup");
                    SqlCommand cmd2 = new SqlCommand(upd_data, con);
                    cmd2.Parameters.AddWithValue("@Verbleibudgetnummerup", Verbleibudgetnummer.Text);
                    cmd2.Parameters.AddWithValue("@Einnahmenup", Convert.ToDecimal(einnahme.Text));
                    cmd2.ExecuteNonQuery();
                    con.Close();
                    einnahme.Text = "";
                    Verbleibudgetnummer.Text = "";


                }
                catch
                {
                    MessageBox.Show("Es Besteht kein Verbindung zu  SQL");
                }
            }
            else
            {
                MessageBox.Show("Gib die Vorhande Verbleibudgetnummer");
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
