using System;
using System.Collections.Generic;

namespace Finazverwaltung_Ende_Arbeit.model
{
    public partial class Einnahmen
    {
        public Einnahmen()
        {
            IdAusgaben = new HashSet<Ausgaben>();
        }

        public int IdEinnahmen { get; set; }
        public decimal? Einnahmen1 { get; set; }

        public virtual ICollection<Ausgaben> IdAusgaben { get; set; }
    }
}
