using UnityEngine;

[CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/" + nameof(SelectableValue), order = 0)]
public class SelectableValue : ScriptableObjectValueBase<ISelectable>
{
    public override void SetValue(ISelectable value)
    {
        CurrentValue?.ExitOutline();
        base.SetValue(value);
        CurrentValue?.EnterOutline();
    }
}

