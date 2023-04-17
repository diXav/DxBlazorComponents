namespace DxBlazorComponents.Components.Models;

public record EventCallbackInfo
{
    string currentStateMessage = string.Empty;
    public Action<string>? OnCurrentStateMessageChanged = null;

    public string CurrentStateMessage
    {
        get => currentStateMessage;
        set
        {
            if (currentStateMessage == value)
                return;

            currentStateMessage = value;
            OnCurrentStateMessageChanged?.Invoke(value);
        }
    }
}