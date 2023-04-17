namespace DxBlazorComponents.Library.Models;

public sealed record DxActionCardState
{
    public string Id { get; set; } = "menu-button-" + Guid.NewGuid().ToString();
    public bool Disabled { get; set; } = false;
    public bool MenuVisible { get; set; } = false;
}