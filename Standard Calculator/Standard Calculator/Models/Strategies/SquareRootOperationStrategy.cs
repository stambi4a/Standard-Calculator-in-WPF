namespace Standard_Calculator.Models.Strategies
{
    using System;

    using Standard_Calculator.Attributes;

    [Component]
    public class SquareRootOperationStrategy
    {
        public decimal Calculate(decimal first)
        {
            return (decimal)(Math.Sqrt((double)first));
        }
    }
}
