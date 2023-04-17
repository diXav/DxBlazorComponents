namespace DxBlazorComponents.Library.Models;

public sealed class DxSize : SmartEnum<DxSize, byte>
{
    public static readonly DxSize None = new(0, string.Empty);
    public static readonly DxSize Sm = new(1, "_sm");
    public static readonly DxSize Md = new(2, "_md");
    public static readonly DxSize Lg = new(3, "_lg");
    public static readonly DxSize Xl = new(4, "_xl");

    public DxSize(byte value, string name) : base(name, value)
    {
    }
}