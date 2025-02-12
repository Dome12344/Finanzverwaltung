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
            SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Finanzverwaltung;Integrated Security = True");
            con.Open();
            string add_data = "INSERT INTO [dbo].[Budgetwert] VALUES (@Budget,@Budgetnummer)";
            SqlCommand cmd = new SqlCommand(add_data, con);
            cmd.Parameters.AddWithValue("@Budget", budget.Text);
            cmd.Parameters.AddWithValue("@Budgetnummer", budgetnummer.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            budget.Text = "";
            budgetnummer.Text = "";
        }

        private void budget_aenderung_uebermitteln_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Finanzverwaltung;Integrated Security = True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update [dbo].[Budgetwert] set Budget = @Budget Where Budgetnummer = @Budgetnummer", con);
            cmd.Parameters.AddWithValue("@Budget", budget.Text);
            cmd.Parameters.AddWithValue("@Budgetnummer", budgetnummer.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            budget.Text = "";
            budgetnummer.Text = "";

        }

        private void zurueck_Click(object sender, RoutedEventArgs e)
        {
            Auswalbildschirm auswalbildschirm = new Auswalbildschirm();
            this.Close();
            auswalbildschirm.Show();
        }
    }
}
