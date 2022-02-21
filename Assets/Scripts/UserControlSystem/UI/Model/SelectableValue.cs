using UnityEngine;

[CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/" + nameof(SelectableValue), order = 0)]
public class SelectableValue : BaseCustomValue<ISelectable>
{
    public override void SetValue(ISelectable value)
    {
        CurrentValue?.ExitOutline();
        CurrentValue = value;
        CurrentValue?.EnterOutline();
        OnNewValue?.Invoke(CurrentValue);
    }
}

