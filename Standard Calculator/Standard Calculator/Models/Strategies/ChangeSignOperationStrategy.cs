namespace Standard_Calculator.Models.Strategies
{
    using Standard_Calculator.Attributes;

    [Component]
    public class ChangeSignOperationStrategy
    {
        public decimal Calculate(decimal first)
        {
            return -first;
        }
    }
}
