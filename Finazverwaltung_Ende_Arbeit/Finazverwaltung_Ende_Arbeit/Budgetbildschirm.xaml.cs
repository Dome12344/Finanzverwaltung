using Finazverwaltung_Ende_Arbeit.model;
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
            string VB = "";
            string BN = "";
            if (Verbleibudgetnummer.Text != "")
            {
                try
                {
                    string pr_data = "SELECT Verbleibudgetnummer FROM [dbo].[Verbleibendesbudget] WHERE Verbleibudgetnummer=@Verbleibudgetnummer";
                    SqlConnection con2 = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Finanzverwaltung;Integrated Security=True");
                    con2.Open();
                    SqlCommand cmd2 = new SqlCommand(pr_data, con2);
                    cmd2.Parameters.AddWithValue("@Verbleibudgetnummer", Verbleibudgetnummer.Text);

                    
                    SqlDataReader reader = cmd2.ExecuteReader();
                    if (reader.Read())
                    {
                        VB = reader["Verbleibudgetnummer"].ToString();
                    }
                    reader.Close();
                    con2.Close();
                }
                catch 
                {
                    MessageBox.Show("Es Besteht kein Verbindung zu  SQL");
                }


                if (budgetnummer.Text != "")
                {
                    try
                    {
                        string BN_data = "SELECT Budgetnummer FROM [dbo].[Budgetwert] WHERE Budgetnummer=@Budgetnummert";
                        SqlConnection con3 = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Finanzverwaltung;Integrated Security=True");
                        con3.Open();
                        SqlCommand cmd3 = new SqlCommand(BN_data, con3);
                        cmd3.Parameters.AddWithValue("@Budgetnummert", budgetnummer.Text);

                        
                        SqlDataReader reader2 = cmd3.ExecuteReader();
                        if (reader2.Read())
                        {
                            BN = reader2["Budgetnummer"].ToString();
                        }
                        reader2.Close();
                        con3.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Es Besteht kein Verbindung zu  SQL");
                    }
                    if (budgetnummer.Text != BN)
                    {
                        if (Verbleibudgetnummer.Text != VB)
                        {


                            try
                            {
                                SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Finanzverwaltung;Integrated Security = True");
                                con.Open();
                                string add_data = "INSERT INTO [dbo].[Budgetwert] VALUES (@Budget,@Budgetnummer)";
                                SqlCommand cmd = new SqlCommand(add_data, con);
                                cmd.Parameters.AddWithValue("@Budget", Convert.ToDecimal(budget.Text));
                                cmd.Parameters.AddWithValue("@Budgetnummer", budgetnummer.Text);
                                cmd.ExecuteNonQuery();
                                con.Close();
                                budgetnummer.Text = "";
                                con.Open();
                                string add_data2 = "INSERT INTO [dbo].[Verbleibendesbudget] VALUES (@Einnahmen,@Ausgaben,@Budget2,@verbleibendesbudget,@Verbleibudgetnummer)";
                                SqlCommand cmd4 = new SqlCommand(add_data2, con);
                                cmd4.Parameters.AddWithValue("@Einnahmen", 0);
                                cmd4.Parameters.AddWithValue("@Ausgaben", 0);
                                cmd4.Parameters.AddWithValue("@Budget2", Convert.ToDecimal(budget.Text));
                                cmd4.Parameters.AddWithValue("@verbleibendesbudget", 0);
                                cmd4.Parameters.AddWithValue("@Verbleibudgetnummer", Verbleibudgetnummer.Text);
                                cmd4.ExecuteNonQuery();
                                con.Close();
                                budget.Text = "";
                                Verbleibudgetnummer.Text = "";
                            }
                            catch
                            {
                                MessageBox.Show("Es Besteht kein Verbindung zu  SQL");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Bitte geben sie eine andere Verbleibudgetnummer ein!");
                        }
                    }
                    
                    else
                    {
                        MessageBox.Show("Bitte geben sie eine andere Budgetnummer ein!");
                    }
                }
                else
                {
                    MessageBox.Show("Bitte  Budgetnummer eingeben!");
                }
            }
            else
            {
                MessageBox.Show("Bitte Verbleibudgetnummer eingeben!");
            }




        }
    



        private void budget_aenderung_uebermitteln_Click(object sender, RoutedEventArgs e)
        {
            string VB = "";
            string BN = "";
            if (Verbleibudgetnummer.Text != "")
            {
                try
                {
                    string pr_data = "SELECT Verbleibudgetnummer FROM [dbo].[Verbleibendesbudget] WHERE Verbleibudgetnummer=@Verbleibudgetnummer";
                    SqlConnection con2 = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Finanzverwaltung;Integrated Security=True");
                    con2.Open();
                    SqlCommand cmd2 = new SqlCommand(pr_data, con2);
                    cmd2.Parameters.AddWithValue("@Verbleibudgetnummer", Verbleibudgetnummer.Text);

                  
                    SqlDataReader reader = cmd2.ExecuteReader();
                    if (reader.Read())
                    {
                        VB = reader["Verbleibudgetnummer"].ToString();
                    }
                    reader.Close();
                    con2.Close();
                }
                catch
                {
                    MessageBox.Show("Es Besteht kein Verbindung zu  SQL");
                }


                if (budgetnummer.Text != "")
                {
                    try
                    {
                        string BN_data = "SELECT Budgetnummer FROM [dbo].[Budgetwert] WHERE Budgetnummer=@Budgetnummert";
                        SqlConnection con3 = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Finanzverwaltung;Integrated Security=True");
                        con3.Open();
                        SqlCommand cmd3 = new SqlCommand(BN_data, con3);
                        cmd3.Parameters.AddWithValue("@Budgetnummert", budgetnummer.Text);

                        
                        SqlDataReader reader2 = cmd3.ExecuteReader();
                        if (reader2.Read())
                        {
                            BN = reader2["Budgetnummer"].ToString();
                        }
                        reader2.Close();
                        con3.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Es Besteht kein Verbindung zu  SQL");
                    }

                    if (Verbleibudgetnummer.Text == VB)
                    {
                        if (budgetnummer.Text == BN)
                        {
                            try
                            {
                                SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Finanzverwaltung;Integrated Security = True");
                                con.Open();
                                SqlCommand cmd = new SqlCommand("Update [dbo].[Budgetwert] set Budget = @Budget Where Budgetnummer = @Budgetnummer", con);
                                cmd.Parameters.AddWithValue("@Budget", Convert.ToDecimal(budget.Text));
                                cmd.Parameters.AddWithValue("@Budgetnummer", budgetnummer.Text);
                                cmd.ExecuteNonQuery();
                                con.Close();

                                budgetnummer.Text = "";

                                con.Open();
                                SqlCommand cmd2 = new SqlCommand("Update [dbo].[Verbleibendesbudget] set Budget = @Budgetup Where Verbleibudgetnummer = @Verbleibudgetnummerup", con);
                                cmd2.Parameters.AddWithValue("@Verbleibudgetnummerup", Verbleibudgetnummer.Text);
                                cmd2.Parameters.AddWithValue("@Budgetup", Convert.ToDecimal(budget.Text));
                                cmd2.ExecuteNonQuery();
                                con.Close();
                                budget.Text = "";
                                Verbleibudgetnummer.Text = "";
                            }
                            catch
                            {
                                MessageBox.Show("Es Besteht keine Sql Verbindung");
                            }
                 
                        }
                        else
                        {
                            MessageBox.Show("Gibt die Vorhanden Budgetnummer ein ist identsich mit der Verbleibungsbudgetnummer!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Gibt die Vorhanden Verbleibungsbudgetnummer ein!");
                    }
                }
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
