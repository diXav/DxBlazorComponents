namespace DxBlazorComponents.Library.Components;

public partial class DxActionCard : ComponentBase
{
    #region Basic Parameters

    [Parameter] public string Class { get; set; } = string.Empty;
    [Parameter] public string InfoText { get; set; } = string.Empty;
    [Parameter] public bool Highlight { get; set; } = false;


    // Content (render fragments)
    [Parameter] public RenderFragment? Menu { get; set; } = null;
    [Parameter] public RenderFragment? ActionMenu { get; set; } = null;
    [Parameter] public RenderFragment? Content { get; set; } = null;
    
    #endregion

    public event EventHandler<DxActionCardState>? OnStateChanged;
    readonly DxActionCardState state = new();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender) return;

        await js.AddOutsideClickListener(DotNetObjectReference.Create(this), nameof(OnCardOutsideClick), state.Id);
    }

    /// <summary>
    /// Allow child buttons (DxButton) to communicate when it's click handler started,
    /// useful for child-parent loading state communication
    /// </summary>
    public void OnChildButtonHandlerStarted()
    {
        state.Disabled = true;

        OnStateChanged?.Invoke(this, state);
        StateHasChanged();
    }

    /// <summary>
    /// Allow child buttons (DxButton) to communicate when it's click handler finished
    /// useful for child-parent loading state communication
    /// </summary>
    public void OnChildButtonHandlerFinished()
    {
        state.Disabled = false;
        state.MenuVisible = false;

        OnStateChanged?.Invoke(this, state);
        StateHasChanged();
    }

    [JSInvokable]
    public void OnCardOutsideClick()
    {
        if (state.Disabled)
            return;

        state.MenuVisible = false;
        OnStateChanged?.Invoke(this, state);
        StateHasChanged();
    }
    
}