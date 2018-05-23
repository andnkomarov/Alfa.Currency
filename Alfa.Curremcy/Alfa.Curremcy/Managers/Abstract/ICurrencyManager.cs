using Alfa.Curremcy.Models;

namespace Alfa.Curremcy.Managers.Abstract
{
    public interface ICurrencyManager
    {
        CurrencyListViewModel GetCurrencyListViewModel();

        decimal GetCurrencyValueById(string id);
    }
}
