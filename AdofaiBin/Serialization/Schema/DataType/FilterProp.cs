// #nullable enable
// namespace AdofaiBin.Serialization.Schema.DataType
// {
//     public readonly struct FilterProp
//     {
//         public enum Kind { Number, Text, Vec2 }
//         public readonly Kind Type;
//         public readonly float Number;
//         public readonly string? Text;
//         public readonly Vec2 Vec;
//         public FilterProp(float number) { Type = Kind.Number; Number = number; Text = null; Vec = default; }
//         public FilterProp(string text) { Type = Kind.Text; Text = text; Number = default; Vec = default; }
//         public FilterProp(Vec2 vec) { Type = Kind.Vec2; Vec = vec; Number = default; Text = null; }
//     }
// }