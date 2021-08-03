namespace mortageAggregator.API.Calculator
{
    public interface ILoanToValueCalculator
    {
        public decimal Calculate(decimal propertyValue, decimal depositAmount);
    }
}