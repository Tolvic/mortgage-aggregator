using Newtonsoft.Json;
using System.ComponentModel;

namespace mortageAggregator.UI.Models
{
    public class Mortgage
    {
        [JsonProperty("lender")]
        public string Lender { get; set; }

        [DisplayName("Interest Rate")]
        public decimal interestRate { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [DisplayName("Max LTV")]
        [JsonProperty("maxLoandToValue")]
        public decimal MaxLoanToValue { get; set; }

    }
}
