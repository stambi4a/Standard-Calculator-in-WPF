namespace Standard_Calculator.Models.Strategies
{
    using Standard_Calculator.Attributes;

    [Component]
    public class AddOperationStrategy
    {
        public decimal Calculate(decimal first, decimal second)
        {
            return first + second;
        } 
    }
}
