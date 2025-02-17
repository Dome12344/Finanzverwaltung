using Microsoft.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Finazverwaltung_Ende_Arbeit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            string Benutzername = nutzername.Text;
            if (login.IsEnabled == true)
            {

                try
                {
                    SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Finanzverwaltung;Integrated Security = True");
                    con.Open();
                    string add_data = "SELECT * FROM [dbo].[Mitarbeiterprofile] where Benutzername=@Benutzername and Passwort=@Passwort ";
                    SqlCommand cmd = new SqlCommand(add_data, con);

                    cmd.Parameters.AddWithValue("@Benutzername", nutzername.Text);
                    cmd.Parameters.AddWithValue("@Passwort", password.Password);
                    cmd.ExecuteNonQuery();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                    nutzername.Text = "";
                    password.Password = "";
                    if (count > 0)
                    {
                        Auswalbildschirm Auswahl = new Auswalbildschirm();
                        this.Close();
                        Auswahl.Show();
                    }
                    else
                    {
                        MessageBox.Show("Passwort oder Username falsch");
                    }

                }
                catch
                {
                    MessageBox.Show("Es Besteht kein Verbindung zu  SQL");
                }
            }
        }
    }
}