namespace Standard_Calculator
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Threading;

    using Standard_Calculator.Core;
    using Standard_Calculator.Data;
    using Standard_Calculator.Events;
    using Standard_Calculator.Exceptions;
    using Standard_Calculator.ExtensionMethods;
    using Standard_Calculator.Interfaces;
    using Standard_Calculator.Utilities;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICalculationRepository calculationRepository;
        private readonly IOperationsContainer operationsContainer;

        public MainWindow()
        {
            IDependencyContainer dependencyContainer = new DependencyContainer();
            this.calculationRepository = new CalculationRepository();
            dependencyContainer.AddDependency(typeof(ICalculationRepository), this.calculationRepository);
            dependencyContainer.AddDependency(typeof(IDependencyContainer), dependencyContainer);
            this.operationsContainer = dependencyContainer.Resolve<IOperationsContainer>();
            this.InitializeComponent();
            this.operationsContainer.CalculationHandler.InputChanged += this.ChangeInputFieldContent;
            this.operationsContainer.CalculationHandler.OutputChanged += this.ChangeOutputFieldContent;
        }

        public MainWindow(ICalculationRepository calculationRepository)
        {
            IDependencyContainer dependencyContainer = new DependencyContainer();
            this.calculationRepository = calculationRepository;
            dependencyContainer.AddDependency(typeof(ICalculationRepository), calculationRepository);
            dependencyContainer.AddDependency(typeof(IDependencyContainer), dependencyContainer);
            this.operationsContainer = dependencyContainer.Resolve<IOperationsContainer>();
            this.InitializeComponent();
        }

        #region ClickEvents
        private void ModeSubMenuItemClick(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuItem;
            if (item == null)
            {
                return;
            }

            var children = new List<MenuItem>();
            children.FindVisualChildren(this.ModeSubMenu);
            foreach (var child in children)
            {
                if (child != null && child.Name != item.Name)
                {
                    child.IsChecked = false;
                }
            }

            item.IsChecked = true;
        }

        private void ViewSubMenuItemClick(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuItem;
            if (item == null)
            {
                return;
            }

            var children = new List<MenuItem>();
            children.FindVisualChildren(this.ViewSubMenu);
            foreach (var child in children)
            {
                if (child != null && child.Name != item.Name)
                {
                    child.IsChecked = false;
                }
            }

            item.IsChecked = true;
        }

        private void ThematicSubSubMenu_OnClick(object sender, RoutedEventArgs e)
        {
            this.ThematicSubSubMenu.IsCheckable = false;
            this.ThematicSubSubMenu.IsChecked = false;
            this.ThematicSubSubMenu.IsSubmenuOpen = true;
        }

        private void ThematicSubMenuLostFocus(object sender, RoutedEventArgs e)
        {
            this.ThematicSubSubMenu.IsCheckable = true;
        }

        private void ThemesMenuItem_OnClickhemesSubSubMenu_OnClick(object sender, RoutedEventArgs e)
        {
            this.ThemesSubMenu.IsCheckable = false;
            this.ThemesSubMenu.IsChecked = false;
            this.ThemesSubMenu.IsSubmenuOpen = true;
        }

        private void ThemesSubMenuLostFocus(object sender, RoutedEventArgs e)
        {
            this.ThemesSubMenu.IsCheckable = true;
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
           Application.Current.Shutdown();
        }

        private void MainGridLoaded(object sender, RoutedEventArgs e)
        {
            this.MouseDown += delegate { this.DragMove(); };
        }

        private void MinimizeButtonClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(((Button)sender).Content.ToString());
        }

        private void ButtonWithSuperscriptedTextClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(Constants.PowerSign);
        }

        #endregion

        #region CustomEvents
        private void ChangeInputFieldContent(object sender, ChangeTextEventArgs args)
        {
            this.InputField.Selection.Text = args.FieldValue;
        }

        private void ChangeOutputFieldContent(object sender, ChangeTextEventArgs args)
        {
            this.OutputField.Selection.Text = args.FieldValue;
        }

        #endregion

        #region ExceptionHandling

        #endregion

        #region KeyboardHandling Evennts
        private void MainWindowDetectKeyDown(object sender, KeyEventArgs e)
        {
            var key = e.Key;
            switch (key)
            {
                case Key.D0:
                case Key.NumPad0:
                    {
                        this.ButtonClick(this.Zero0DigitButton, null);
                    }

                    break;
                case Key.D1:
                case Key.NumPad1:
                    {
                        this.ButtonClick(this.One1DigitButton, null);
                    }

                    break;
                case Key.D2:
                case Key.NumPad2:
                    {
                        this.ButtonClick(this.Two2DigitButton, null);
                    }

                    break;
                case Key.D3:
                case Key.NumPad3:
                    {
                        this.ButtonClick(this.Three3DigitButton, null);
                    }

                    break;
                case Key.D4:
                case Key.NumPad4:
                    {
                        this.ButtonClick(this.Four4DigitButton, null);
                    }

                    break;
                case Key.D5:
                case Key.NumPad5:
                    {
                        this.ButtonClick(this.Five5DigitButton, null);
                    }

                    break;
                case Key.D6:
                case Key.NumPad6:
                    {
                        this.ButtonClick(this.Six6DigitButton, null);
                    }

                    break;
                case Key.D7:
                case Key.NumPad7:
                    {
                        this.ButtonClick(this.Seven7DigitButton, null);
                    }

                    break;
                case Key.D8:
                case Key.NumPad8:
                    {
                        this.ButtonClick(this.Eight8DigitButton, null);
                    }

                    break;
                case Key.D9:
                case Key.NumPad9:
                    {
                        this.ButtonClick(this.Nine9DigitButton, null);
                    }

                    break;
                case Key.Add:
                    {
                        this.ButtonClick(this.AddOperationButton, null);
                    }

                    break;
                case Key.Subtract:
                    {
                        this.ButtonClick(this.SubtractOperationButton, null);
                    }

                    break;
                case Key.Multiply:
                    {
                        this.ButtonClick(this.MultiplyOperationButton, null);
                    }

                    break;
                case Key.Divide:
                    {
                        this.ButtonClick(this.DivideOperationButton, null);
                    }

                    break;
                case Key.Enter:
                    {
                        this.ButtonClick(this.EqualsButton, null);
                    }

                    break;

                case Key.Back:
                    {
                        this.ButtonClick(this.DeleteSpecialButton, null);
                    }

                    break;
                default:
                    return;

            }

            this.ClearAllButton.IsEnabled = true;
        }

        #endregion
        private void MainWindowPreviewKeyDown(object sender, KeyEventArgs e)
        {
            var key = e.Key;
            if (key == Key.Enter)
            {
                this.EqualsButton.Focus();
            }
        }
    }
}
