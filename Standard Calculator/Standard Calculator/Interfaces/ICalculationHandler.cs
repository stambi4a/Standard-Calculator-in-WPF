namespace Standard_Calculator.Interfaces
{
    using System;
    using System.Threading;

    using Standard_Calculator.Events;

    public interface ICalculationHandler
    {
        event ChangeTextEventHandler InputChanged;
        event ChangeTextEventHandler OutputChanged;

        event EventHandler ReceiveNonEmptyResult;

        void Execute(string input);

        void Clear();

        void CalculationHandlerExceptionHandlingMethod(Exception originalException);
    }
}
