using System;
using System.Collections.Generic;

namespace Finazverwaltung_Ende_Arbeit.model
{
    public partial class Budgetwert
    {
        public int IdBudgetwert { get; set; }
        public decimal? Budget { get; set; }
        public int? Budgetnummer { get; set; }
    }
}
