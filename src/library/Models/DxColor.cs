namespace DxBlazorComponents.Library.Models;

public sealed class DxColor : SmartEnum<DxColor, byte>
{
    public static readonly DxColor None = new(0, string.Empty);
    public static readonly DxColor Default = new(1, "_default");
    public static readonly DxColor Primary = new(2, "_primary");
    public static readonly DxColor Secondary = new(3, "_secondary");
    public static readonly DxColor Success = new(4, "_success");
    public static readonly DxColor Error = new(5, "_error");

    public DxColor(byte value, string name) : base(name, value)
    {
    }
}