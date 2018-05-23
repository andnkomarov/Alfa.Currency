using Newtonsoft.Json;

namespace Alfa.Curremcy.Models.BusinessModels
{
    public class Currency
    {
        public string Id { get; set; }

        public int NumCode { get; set; }

        public string CharCode { get; set; }

        public int Nominal { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }

        [JsonProperty("Previous")]
        public decimal PreviousValue { get; set; }
    }
}
