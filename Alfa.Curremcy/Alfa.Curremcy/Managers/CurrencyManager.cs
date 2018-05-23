using System;
using System.Linq;
using System.Net;
using Alfa.Curremcy.Config;
using Alfa.Curremcy.Managers.Abstract;
using Alfa.Curremcy.Models;
using Alfa.Curremcy.Models.BusinessModels;
using AutoMapper;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Alfa.Curremcy.Managers
{
    public class CurrencyManager : ICurrencyManager
    {
        private readonly IOptions<AlfaCurrencyConfig> _config;
        private readonly IMapper _mapper;

        private const string CannotFindSelectedCurrency = "Не удалось найти выбранную валюту";
        private const string CurrencyListIsEmpty = "Списки валют пусты";

        public CurrencyManager(IOptions<AlfaCurrencyConfig> config,
            IMapper mapper)
        {
            _config = config;
            _mapper = mapper;
        }

        public CurrencyListViewModel GetCurrencyListViewModel()
        {
            var currencies = GetCurrencies();

            return _mapper.Map<CurrencyListViewModel>(currencies);
        }

        public decimal GetCurrencyValueById(string id)
        {
            var currencies = GetCurrencies();

            var currencyValue = currencies.Valute.Values.FirstOrDefault(v => v.Id == id);

            return currencyValue?.Value ?? throw new Exception(CannotFindSelectedCurrency);
        }

        private CurrenciesList GetCurrencies()
        {
            var currencyString = DownloadCurrencyString(_config.Value.CurrencySourceUrl);

            if (string.IsNullOrEmpty(currencyString))
            {
                throw new Exception(CurrencyListIsEmpty);
            }

            return JsonConvert.DeserializeObject<CurrenciesList>(currencyString);
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
