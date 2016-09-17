namespace Standard_Calculator.Attributes
{
    public class ConvertorComponentAttribute : ComponentAttribute
    {
        public ConvertorComponentAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
