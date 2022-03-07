using UnityEngine;

public interface ISelectable : IHealthHolder, IIconHolder
{
    Transform PivotPoint { get; }
    void EnterOutline();
    void ExitOutline();
}
