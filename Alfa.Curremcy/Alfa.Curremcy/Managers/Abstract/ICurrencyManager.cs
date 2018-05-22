using Alfa.Curremcy.Models;

namespace Alfa.Curremcy.Managers.Abstract
{
    public interface ICurrencyManager
    {
        CurrencySetViewModel GetCurrencyViewModel();

        decimal GetCurrencyValueById(string id);
    }
}
