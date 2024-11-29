using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Finanzverwaltung
{
    public class Program
    {
        static void Main(string[] args)
        {
            finazverwaltung verwaltung = new finazverwaltung(10000);
            string nochmal = "";
            string weiter = "";
            Login Profil = new Login();
            string user = "";
            while (nochmal!= "Erfolgreich")
            {
                Console.Write("Geben sie ihr Username ein:");
                string username = Console.ReadLine();
                Console.Write("Geben sie ihr Passwort ein:");
                string Passwort = Console.ReadLine();
                user = username;
                nochmal = Profil.login(username, Passwort);             
            }
            while(true)
            {
                Console.WriteLine("\n--- Schwimmbad Finanzverwaltung ---");
                Console.WriteLine("1. Einnahme hinzufügen");
                Console.WriteLine("2. Ausgabe hinzufügen");
                Console.WriteLine("3. Finanzübersicht anzeigen");
                Console.WriteLine("4. Budget anpassen");
                Console.WriteLine("5. Beenden");
                Console.Write("Wählen Sie eine Option: ");
                int eingabe = Convert.ToInt32(Console.ReadLine());
                if(eingabe ==1)
                {
                    Console.Write("Geben Sie den Betrag der Einnahme ein: ");
                    decimal einnahme = Convert.ToDecimal(Console.ReadLine());
                    verwaltung.Einnahm_Hinzufügen(einnahme);

                }
                else if( eingabe ==2) 
                {
                    Console.Write("Geben Sie den Betrag der Ausgabe ein: ");
                    decimal ausgabe = Convert.ToDecimal(Console.ReadLine());
                    verwaltung.Ausgabe_Hinzufügen(ausgabe);

                }
                else if (eingabe == 3)
                {
                    verwaltung.Zeige_Kennzahlen();
                }
                else if (eingabe == 4)
                {
                    Console.Write("Geben Sie das neue Budget ein: ");
                    decimal neuesBudget = Convert.ToDecimal(Console.ReadLine());
                    verwaltung.Budget_Anpassung(neuesBudget);

                }
                else if (eingabe == 5)
                {
                    Console.WriteLine("Programm wird beendet.");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte wählen Sie eine gültige Option.");

                }

            }
            //Console.WriteLine(user);
            //Console.Write("Programm beenden:");

            //string antwort = Console.ReadLine();
            //if (antwort== "Ja")
            //{
            //    Environment.Exit(0);
            //}
        }
    }
}