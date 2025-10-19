namespace AdofaiBin.Serialization.Schema.DataType;

public readonly struct EnumValue
{
    // can be int or string
    public readonly object Value;
    public readonly string TypeName;

    public EnumValue(int value, string typeName)
    {
        Value = value;
        TypeName = typeName;
    }
}