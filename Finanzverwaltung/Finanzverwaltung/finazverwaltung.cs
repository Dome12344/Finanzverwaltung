using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzverwaltung
{
    public class finazverwaltung
    {
        
        private List<decimal>Einnahmen = new List<decimal>();
        private List<decimal>Ausgaben = new List<decimal>();
        private decimal Budget { get; set; }

        public finazverwaltung(decimal budget)
        {
            Budget = budget;
        }
        public void Einnahm_Hinzufügen(decimal betrag)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Einnahmen.Add(betrag);
            Console.Out.WriteLine($"Einnahme von {betrag} € wurde hinzugefügt");
        }
        public void Ausgabe_Hinzufügen(decimal betrag)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Ausgaben.Add(betrag);
            Console.Out.WriteLine($"Ausgabe von {betrag} € wurde hinzugefügt");
        }
        public decimal Berechne_Gesamteinnahmen()
        {
            decimal gesamtsumme = 0;
            foreach(var einnahmen in Einnahmen)
            {
                gesamtsumme += einnahmen;
            }
            return gesamtsumme;
        }
        public decimal Berechne_Gesamtausgaben()
        {
            decimal gesamtsumme = 0;
            foreach (var ausgaben in Ausgaben)
            {
                gesamtsumme += ausgaben;
            }
            return gesamtsumme;
        }
        public decimal Berechene_Verbleibendes_Budget()
        {
            decimal gesamtEinnahmen = Berechne_Gesamteinnahmen();
            decimal gesamtAusgaben = Berechne_Gesamtausgaben();
            return Budget + gesamtEinnahmen - gesamtAusgaben;
        }
        public void Zeige_Kennzahlen()
        {
            Console.OutputEncoding = Encoding.UTF8;
            decimal gesamtEinnahmen = Berechne_Gesamteinnahmen();
            decimal gesamtAusgaben = Berechne_Gesamtausgaben();
            decimal verbleibendesBudget = Berechene_Verbleibendes_Budget();
            Console.WriteLine("\n--- Finanzübersicht ---");
            Console.Out.WriteLine($"Gesamteinnahmen: {gesamtEinnahmen} €");
            Console.Out.WriteLine($"Gesamtausgaben: {gesamtAusgaben} €");
            Console.Out.WriteLine($"Verbleibendes Budget: {verbleibendesBudget} €");
        }
        public void Budget_Anpassung(decimal neuerBetrag)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Budget = neuerBetrag;
            Console.Out.WriteLine($"Das Budget wurde auf {Budget} € angepasst");
        }







    }
}
