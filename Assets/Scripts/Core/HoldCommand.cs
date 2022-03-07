using UnityEngine;

public class HoldCommand : IStopCommand
{
    public GameObject UnitPrefab => _unitPrefab;
    private GameObject _unitPrefab;

    public HoldCommand(GameObject unitPrefab = null)
    {
        _unitPrefab = unitPrefab;
    }
}
