namespace mortageAggregator.API.Calculator
{
    public class LoanToValueCalculator : ILoanToValueCalculator
    {
        public decimal Calculate(decimal propertyValue, decimal depositAmount)
        {
            var mortageAmount = propertyValue - depositAmount;

            return mortageAmount / propertyValue * 100;
        }
    }
}
