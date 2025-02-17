using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            
            string nummer = ausgabennummer.Text;
            string SQLnummer = "";
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
            if (VB == Verbleibudgetnummer.Text)
            {
                
                if (nummer != "")
                {

                    try
                    {
                        string pr_data = "SELECT Ausgabennummer FROM [dbo].[Ausgaben] WHERE Ausgabennummer=@Ausgabennummer";
                        SqlConnection con2 = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Finanzverwaltung;Integrated Security=True");
                        con2.Open();
                        SqlCommand cmd2 = new SqlCommand(pr_data, con2);
                        cmd2.Parameters.AddWithValue("@Ausgabennummer", ausgabennummer.Text);

                        // Auslesen der Ausgabennummer, wenn vorhanden
                        SqlDataReader reader = cmd2.ExecuteReader();
                        if (reader.Read())
                        {
                            SQLnummer = reader["Ausgabennummer"].ToString();
                        }
                        reader.Close();
                        con2.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Es Besteht kein Verbindung zu  SQL");
                    }


                    if (nummer != SQLnummer)
                    {
                        try
                        {
                            SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Finanzverwaltung;Integrated Security = True");
                            con.Open();
                            string add_data = "INSERT INTO [dbo].[Ausgaben] VALUES (@Ausgaben,@Ausgabennummer)";
                            SqlCommand cmd = new SqlCommand(add_data, con);
                            cmd.Parameters.AddWithValue("@Ausgaben", Convert.ToDecimal(ausgaben.Text));
                            cmd.Parameters.AddWithValue("@Ausgabennummer", ausgabennummer.Text);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            con.Open();
                            ausgabennummer.Text = "";
                            string upd_data = ("Update [dbo].[Verbleibendesbudget] set Ausgaben = @Ausgabenup Where Verbleibudgetnummer = @Verbleibudgetnummerup");
                            SqlCommand cmd2 = new SqlCommand(upd_data, con);
                            cmd2.Parameters.AddWithValue("@Verbleibudgetnummerup", Verbleibudgetnummer.Text);
                            cmd2.Parameters.AddWithValue("@Ausgabenup", Convert.ToDecimal(ausgaben.Text));
                            cmd2.ExecuteNonQuery();
                            con.Close();
                            ausgaben.Text = "";
                            Verbleibudgetnummer.Text = "";
                        }
                        catch
                        {
                            MessageBox.Show("Es Besteht kein Verbindung zu  SQL");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bitte andere Ausgabennummer eingeben!");
                    }
                }
                else
                {
                    MessageBox.Show("Bitte Ausgaben nummer eingeben!");
                }
            }
            else
            {
                MessageBox.Show("Gib die Vorhande Verbleibudgetnummer");
            }
        }

        private void ausgaben_aenderung_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
