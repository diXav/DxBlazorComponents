namespace DxBlazorComponents.Library.Components;

public partial class DxButton : ComponentBase
{
    #region basic parameters

    [Parameter] public string Id { get; set; } = string.Empty;
    [Parameter] public string Text { get; set; } = string.Empty;
    [Parameter] public DxSize Size { get; set; } = DxSize.Md;
    [Parameter] public DxColor Color { get; set; } = DxColor.Default;
    [Parameter] public DxVariant Variant { get; set; } = DxVariant.Solid;

    // Style
    [Parameter] public string Class { get; set; } = string.Empty;
    [Parameter] public string IconClass { get; set; } = string.Empty;
    [Parameter] public string LeftIconClass { get; set; } = string.Empty;
    [Parameter] public string RightIconClass { get; set; } = string.Empty;

    // Flags
    [Parameter] public bool IsFullWidth { get; set; }
    [Parameter] public bool IsHidden { get; set; }
    [Parameter] public bool IsLoadingLocked { get; set; }
    [Parameter] public bool IsDisabled { get; set; }

    // Events
    [Parameter] public EventCallback<DxEventCallbackInfo> OnClick { get; set; }

    #endregion

    #region cascading parameters

    [CascadingParameter] public DxActionCard? ParentActionCard { get; set; } = null;
    
    #endregion

    bool loading;
    string loadingText = "Cargando";
    bool LoadingState => loading || IsLoadingLocked;
    bool DisabledState => IsDisabled || forceDisabled;
    bool forceDisabled = false;
    bool HasIcon => IconClass != string.Empty;
    bool HasLeftIcon => LeftIconClass != string.Empty;
    bool HasRightIcon => RightIconClass != string.Empty;

    protected override void OnInitialized()
    {
        if (ParentActionCard != null)
        {
            ParentActionCard.OnStateChanged += OnParentCardStateChanged;
        }
    }

    void OnParentCardStateChanged(object? s, DxCard.DxCardState state)
    {
        forceDisabled = state.Disabled;
    }

    public void Dispose()
    {
        if (ParentActionCard != null)
            ParentActionCard.OnStateChanged -= OnParentCardStateChanged;
    }

    

    async Task InvokeClick()
    {
        await Task.Delay(10); // validator.Validate() bugfix
        if (!OnClick.HasDelegate && !OnClick.HasDelegate)
        {
            logger.LogWarning("No click handler defined for button");
            return;
        }

        // Simple click handler
        if (OnClick.HasDelegate)
        {
            loading = true;
            StateHasChanged();

            await OnClick.InvokeAsync();

            loading = false;
            return;
        }

        // Task handler
        var callbackInfo = new DxEventCallbackInfo();

        callbackInfo.OnCurrentStateMessageChanged = newMessage =>
        {
            loadingText = newMessage;
            StateHasChanged();
        };

        if (ParentActionCard is not null)
            ParentActionCard.OnChildButtonHandlerStarted();

        loading = true;
        await InvokeAsync(StateHasChanged);
        
        await OnClick.InvokeAsync(callbackInfo);
        loading = false;

        callbackInfo.OnCurrentStateMessageChanged = null;

        if (ParentActionCard is not null)
            ParentActionCard.OnChildButtonHandlerFinished();
    }

    
}