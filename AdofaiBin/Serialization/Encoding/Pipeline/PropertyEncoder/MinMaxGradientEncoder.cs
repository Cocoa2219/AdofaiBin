#nullable enable
using AdofaiBin.Serialization.Encoding.IO;
using AdofaiBin.Serialization.Schema;
using AdofaiBin.Serialization.Schema.DataType;

namespace AdofaiBin.Serialization.Encoding.Pipeline.PropertyEncoder;

public class MinMaxGradientEncoder : IPropertyEncoder
{
    /// <inheritdoc />
    public PropertyType Handles { get; } = PropertyType.MinMaxGradient;

    /// <inheritdoc />
    public void Write(ref WriteCursor cursor, object? value)
    {
        var gradient = (MinMaxGradient?)value ?? new MinMaxGradient();
        cursor.WriteByte((byte)gradient.Mode);
        // cursor.WriteByte(gradient.ColorMin?.A ?? 255);
        // cursor.WriteByte(gradient.ColorMin?.R ?? 0);
        // cursor.WriteByte(gradient.ColorMin?.G ?? 0);
        // cursor.WriteByte(gradient.ColorMin?.B ?? 0);
        //
        // cursor.WriteByte(gradient.ColorMax?.A ?? 255);
        // cursor.WriteByte(gradient.ColorMax?.R ?? 0);
        // cursor.WriteByte(gradient.ColorMax?.G ?? 0);
        // cursor.WriteByte(gradient.ColorMax?.B ?? 0);
        cursor.WriteColor(gradient.ColorMin);
        cursor.WriteColor(gradient.ColorMax);

        cursor.WriteVarInt(gradient.GradientMin?.Count ?? 0);
        if (gradient.GradientMin != null)
        {
            foreach (var (t, c) in gradient.GradientMin)
            {
                cursor.WriteFloat(t);
                // cursor.WriteByte(c.A);
                // cursor.WriteByte(c.R);
                // cursor.WriteByte(c.G);
                // cursor.WriteByte(c.B);

                cursor.WriteColor(c);
            }
        }

        cursor.WriteVarInt(gradient.GradientMax?.Count ?? 0);
        if (gradient.GradientMax != null)
        {
            foreach (var (t, c) in gradient.GradientMax)
            {
                cursor.WriteFloat(t);
                // cursor.WriteByte(c.A);
                // cursor.WriteByte(c.R);
                // cursor.WriteByte(c.G);
                // cursor.WriteByte(c.B);

                cursor.WriteColor(c);
            }
        }
    }
}