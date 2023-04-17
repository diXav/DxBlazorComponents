namespace Microsoft.JSInterop;

using System.Text.Json;

static class JsExtension
{
    public static async Task Focus(this IJSRuntime js, string id)
    {
        await Task.Delay(20); //For rendering state changed
        await js.InvokeVoidAsync("window.dx.focus", id);
        await Task.Delay(20); //For rendering state changed
    }

    public static ValueTask<bool> GetDarkMode(this IJSRuntime js)
    {
        return js.InvokeAsync<bool>("window.dx.getDarkMode");
    }

    public static ValueTask<bool> ToggleDarkMode(this IJSRuntime js)
    {
        return js.InvokeAsync<bool>("window.dx.toggleDarkMode");
    }

    public static ValueTask ClickButtonWithId(this IJSRuntime js, string buttonId)
    {
        return js.InvokeVoidAsync($"window.dx.clickButtonWithId", buttonId);
    }
    
    public static ValueTask AddOutsideClickListener(this IJSRuntime js, object dotnetInstance, string callbackName, string elementId)
    {
        return js.InvokeVoidAsync("window.dx.addOutsideClickListener", dotnetInstance, callbackName, elementId);
    }

    public static ValueTask RemoveOutsideClickListener(this IJSRuntime js, string elementId)
    {
        return js.InvokeVoidAsync("window.dx.removeOutsideClickListener", elementId);
    }
}