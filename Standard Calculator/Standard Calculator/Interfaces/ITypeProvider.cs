namespace Standard_Calculator.Interfaces
{
    using System;

    public interface ITypeProvider
    {
        Type[] GetTypesByAttribute(Type attrType);

        Type ProvideType(string typeName);
    }
}
