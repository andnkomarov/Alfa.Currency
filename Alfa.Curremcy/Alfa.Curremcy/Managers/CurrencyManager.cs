using System;
using System.Linq;
using System.Net;
using Alfa.Curremcy.Config;
using Alfa.Curremcy.Managers.Abstract;
using Alfa.Curremcy.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Alfa.Curremcy.Managers
{
    public class CurrencyManager : ICurrencyManager
    {
        private readonly IOptions<AlfaCurrencyConfig> _config;

        public CurrencyManager(IOptions<AlfaCurrencyConfig> config)
        {
            _config = config;
        }
        
        public CurrencySetViewModel GetCurrencyViewModel()
        {
            var currencyViewModel = GetCurrencies();

            var tmpList = currencyViewModel.Valute.Values.Select(currency => new SelectListItem
            {
                Value = currency.Id,
                Text = currency.CharCode
            }).ToList();

            currencyViewModel.Currencies2 = tmpList;

            return currencyViewModel;
        }

        public decimal GetCurrencyValueById(string id)
        {
            var currencyViewModel = GetCurrencies();

            var currencyValue = currencyViewModel.Valute.Values.FirstOrDefault(v => v.Id == id);

            return currencyValue?.Value ?? throw new Exception("Не удалось найти выбранную валюту");
        }

        private CurrencySetViewModel GetCurrencies()
        {
            try
            {
                var currencyString = DownloadCurrencyString(_config.Value.CurrencySourceUrl);
                
                if (string.IsNullOrEmpty(currencyString))
                {
                    throw new Exception("Списки валют пусты");
                }

                return JsonConvert.DeserializeObject<CurrencySetViewModel>(currencyString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private string DownloadCurrencyString(string url)
        {
            using (var webClient = new WebClient())
            {
                var response = webClient.DownloadString(url);
                return response;
            }
        }
    }
}
