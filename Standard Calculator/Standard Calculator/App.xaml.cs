namespace Standard_Calculator
{
    using System;
    using System.Windows;
    using System.Windows.Threading;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        //private readonly ICalculationRepository calculationRepository;
        //private readonly IOperationsContainer operationsContainer;

        public App()
        {
            //IDependencyContainer dependencyContainer = new DependencyContainer();
            //this.calculationRepository = new CalculationRepository();
            //dependencyContainer.AddDependency(typeof(ICalculationRepository), this.calculationRepository);
            //dependencyContainer.AddDependency(typeof(IDependencyContainer), dependencyContainer);
            //this.operationsContainer = dependencyContainer.Resolve<IOperationsContainer>();
            this.InitializeComponent();
        }

        //public App(ICalculationRepository calculationRepository)
        //{
        //    IDependencyContainer dependencyContainer = new DependencyContainer();
        //    this.calculationRepository = calculationRepository;
        //    dependencyContainer.AddDependency(typeof(ICalculationRepository), calculationRepository);
        //    dependencyContainer.AddDependency(typeof(IDependencyContainer), dependencyContainer);
        //    this.operationsContainer = dependencyContainer.Resolve<IOperationsContainer>();
        //    this.InitializeComponent();
        //}

        public void ApplicationExit(object sender, ExitEventArgs e)
        {
            this.Shutdown();
        }

        [STAThread]
        public static void Main()
        {
            var mainWindow = new MainWindow();
            var app = new App();
            app.Run();
        }
    }
}
