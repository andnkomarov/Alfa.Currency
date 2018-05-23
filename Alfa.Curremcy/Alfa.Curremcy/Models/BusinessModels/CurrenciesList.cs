using System;
using System.Collections.Generic;
using Alfa.Curremcy.Models.BusinessModels;

namespace Alfa.Curremcy.Models.BusinessModels
{
    public class CurrenciesList
    {
        public DateTime Date { get; set; }

        public DateTime PreviousDate { get; set; }

        public string PreviousURL { get; set; }

        public DateTime Timestamp { get; set; }

        public Dictionary<string, Currency> Valute { get; set; }
    }
}
