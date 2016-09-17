namespace Standard_Calculator.Models.Strategies
{
    using System;

    using Standard_Calculator.Attributes;

    [Component]
    public class PowerOperationStrategy
    {
        public decimal Calculate(decimal first)
        {
            return (decimal)Math.Pow((double)first, 2);
        }
    }
}
