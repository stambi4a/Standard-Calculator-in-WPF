namespace Standard_Calculator.Models.Strategies
{
    using Standard_Calculator.Attributes;

    [Component]
    public class SubtractOperationStrategy
    {
        public decimal Calculate(decimal first, decimal second)
        {
            return first - second;
        }
    }
}
