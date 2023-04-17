namespace DxBlazorComponents.Library.Models;

public sealed class DxVariant : SmartEnum<DxVariant, byte>
{
    public static readonly DxVariant None = new(0, string.Empty);
    public static readonly DxVariant Solid = new(1, "_solid");
    public static readonly DxVariant Outline = new(2, "_outline");
    public static readonly DxVariant Text = new(3, "_text");
    public static readonly DxVariant Link = new(4, "_link");

    public DxVariant(byte value, string name) : base(name, value)
    {
    }
}