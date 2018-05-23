using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Alfa.Curremcy.Models
{
    public class CurrencyListViewModel
    {
        public DateTime Date { get; set; }

        public IEnumerable<CurrencyViewModel> Currencies { get; set; }

        public IEnumerable<SelectListItem> SelectedCurrencyItems { set; get; }

        public string SelectedCurrencyId { get; set; }
    }
}
