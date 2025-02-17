using System;
using System.Collections.Generic;

namespace Finazverwaltung_Ende_Arbeit.model
{
    public partial class Mitarbeiterprofile
    {
        public int MitarbeiterId { get; set; }
        public string? Mitarbeiternummer { get; set; }
        public string? Vorname { get; set; }
        public string? Nachname { get; set; }
        public string? Benutzername { get; set; }
        public string? Passwort { get; set; }
        public string? Email { get; set; }
        public int? Telefonnummer { get; set; }
        public int? Diensthandynummer { get; set; }
    }
}
