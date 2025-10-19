// #nullable enable
// using AdofaiBin.Serialization.Encoding.IO;
// using AdofaiBin.Serialization.Schema;
// using AdofaiBin.Serialization.Schema.DataType;
//
// namespace AdofaiBin.Serialization.Encoding.Pipeline.PropertyEncoder;
//
// public class FilterPropertiesEncoder : IPropertyEncoder
// {
//     /// <inheritdoc />
//     public PropertyType Handles { get; } = PropertyType.FilterProperties;
//
//     /// <inheritdoc />
//     public void Write(ref WriteCursor cursor, object? value)
//     {
//         if (value is not FilterProp filterProp)
//         {
//             filterProp = new FilterProp();
//         }
//
//         cursor.WriteByte((byte)filterProp.Type);
//         cursor.WriteFloat(filterProp.Number);
//         cursor.WriteUtf8String(filterProp.Text);
//         cursor.WriteVec2(filterProp.Vec);
//     }
// }