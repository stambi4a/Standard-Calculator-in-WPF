namespace Standard_Calculator.Interfaces
{
    using System;
    using System.Threading;

    public interface ICalculationExecutor
    {
        object[] ProcessInput(string input);

        void Clear();

        void ClearAll();

        void CalculationExecutorThreadExceptionHandlingMethod(object sender, ThreadExceptionEventArgs args);
    }
}
