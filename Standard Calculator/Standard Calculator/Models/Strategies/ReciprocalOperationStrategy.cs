namespace Standard_Calculator.Models.Strategies
{
    using Standard_Calculator.Attributes;

    [Component]
    public class ReciprocalOperationStrategy
    {
        public decimal Calculate(decimal first)
        {
            return 1 / first;
        }
    }
}