namespace Standard_Calculator.Core
{
    using System;
    using System.Reflection;
    using System.Threading;
    using System.Windows;

    using Standard_Calculator.Attributes;
    using Standard_Calculator.Events;
    using Standard_Calculator.Exceptions;
    using Standard_Calculator.Interfaces;

    [Core]
    public class CalculationHandler : ICalculationHandler
    {
        [Inject]
        private readonly ICalculationExecutor calculationExecutor;

        private readonly IRepositoryHandler repositoryHandler;
        private readonly IDependencyContainer dependencyContainer;
        private readonly IMethodInvoker methodInvoker;

        private string currentOutput;
        private string currentInput;

        public event ChangeTextEventHandler InputChanged;
        public event ChangeTextEventHandler OutputChanged;

        public event EventHandler ReceiveNonEmptyResult;

        public CalculationHandler(
            IRepositoryHandler repositoryHandler, 
            IDependencyContainer dependencyContainer,
            IMethodInvoker methodInvoker)
        {
            this.repositoryHandler = repositoryHandler;
            this.dependencyContainer = dependencyContainer;
            this.methodInvoker = methodInvoker;
            this.SetDefaults();

            //Application.ThreadException += this.CalculationHandlerThreadExceptionHandlingMethod;
        }

        public string CurrentInput
        {
            get
            {
                return this.currentInput;
            }

            private set
            {
                this.OnInputChanged(this, new ChangeTextEventArgs(value));
                this.currentInput = value;
            }
        }
        public string CurrentOutput
        {
            get
            {
                return this.currentOutput;
            }

            private set
            {
                this.OnOutputChanged(this, new ChangeTextEventArgs(value));
                this.currentOutput = value;
            }
        }

        public void Execute(string input)
        {
            var result = this.calculationExecutor.ProcessInput(input);
            if (result == null)
            {
                return;
            }

            if (result[2] != null)
            {
                this.SetInput(0);
                this.SetOutput(0);
                
            }
 
            if (result[0] != null)
            {
                this.SetInput(result[0]);
            }

            if (result[1] == null)
            {
                return;
            }

            this.OnReceiveResult(this, null);
            this.SetOutput(result[1]);
        }

        public void OnInputChanged(object sender, ChangeTextEventArgs args)
        {
            this.InputChanged?.Invoke(sender, args);
        }

        public void OnOutputChanged(object sender, ChangeTextEventArgs args)
        {
            this.OutputChanged?.Invoke(sender, args);
        }

        public void Clear()
        {
            this.calculationExecutor.Clear();
        }

        private void SetInput(object inputField)
        {
            this.CurrentInput = inputField.ToString();
        }

        private void SetOutput(object outputField)
        {
            this.CurrentOutput = outputField.ToString();
        }

        private void SetDefaults()
        {
            this.SetInput(0);
            this.SetOutput(0);
        }

        public void CalculationHandlerExceptionHandlingMethod(Exception originalException)
        {
            var exception = originalException;
            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
            }

            if (exception is OverflowException)
            {
                MessageBox.Show("Operation overflows numeric Type");
            }

            if(exception is DivideByZeroException)
            {
                MessageBox.Show("Division by zero is indefinite operation");
            }
        }

        public void OnReceiveResult(object sender, EventArgs args)
        {
            this.ReceiveNonEmptyResult?.Invoke(sender, args);
        }
    }
}