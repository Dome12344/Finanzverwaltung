using System;
using System.Collections.Generic;

namespace Finazverwaltung_Ende_Arbeit.model
{
    public partial class Ausgaben
    {
        public Ausgaben()
        {
            IdEinnahmen = new HashSet<Einnahmen>();
        }

        public int IdAusgaben { get; set; }
        public decimal? Ausgaben1 { get; set; }
        public int? Ausgabennummer { get; set; }

        public virtual ICollection<Einnahmen> IdEinnahmen { get; set; }
    }
}
