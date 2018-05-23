﻿
namespace Alfa.Curremcy.Models
{
    public class CurrencyViewModel
    {
        public string CharCode { get; set; }

        public int Nominal { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }

        public decimal PreviousValue { get; set; }
    }
}
