namespace DxBlazorComponents.Components;

public partial class DxInputCheckbox : ComponentBase
{

#region Generic Parameters

    [Parameter] public string Id { get; set; } = string.Empty;
    [Parameter] public string Label { get; set; } = string.Empty;
    [Parameter] public bool Disabled { get; set; } = true;
    [Parameter] public EventCallback OnEnterKeyPress { get; set; }
    [Parameter] public bool Visible { get; set; } = true;

    /// <summary>
    /// Default: DxComSize.Medium
    /// </summary>
    [Parameter] public DxComSize Size { get; set; } = DxComSize.Medium;

    /// <summary>
    /// Input element class (element)
    /// </summary>
    [Parameter] public string InnerClass { get; set; } = string.Empty;

    /// <summary>
    /// Input container element class (div)
    /// </summary>
    [Parameter] public string Class { get; set; } = string.Empty;

#endregion

#region Cascading parameters

    [CascadingParameter] public DxCard? ParentCard { get; set; } = null;

    #endregion

    #region Property: Value (two way binding)

    bool _value;

    [Parameter] public bool Value
    {
        get => _value;
        set
        {
            if (_value == value) return;
            _value = value;
            ValueChanged.InvokeAsync(value);
        }
    }

    [Parameter] public EventCallback<bool> ValueChanged { get; set; }

#endregion

    bool forceDisabled;

    protected override void OnInitialized()
    {
        if (ParentCard != null)
        {
            ParentCard.OnStateChanged += OnParentCardStateChanged;
        }
    }

    void OnParentCardStateChanged(object? s, DxCard.DxCardState state)
    {
        forceDisabled = state.Disabled;
    }
}