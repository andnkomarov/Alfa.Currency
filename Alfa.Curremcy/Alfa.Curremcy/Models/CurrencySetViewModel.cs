using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Alfa.Curremcy.Models
{
    public class CurrencySetViewModel
    {
        public DateTime Date { get; set; }

        public DateTime PreviousDate { get; set; }

        public string PreviousURL { get; set; }

        public DateTime Timestamp { get; set; }

        public Dictionary<string, CurrencyViewModel> Valute { get; set; }

        public List<SelectListItem> Currencies2 { set; get; }

        public string SelectedCurrencyId { get; set; }
    }
}
