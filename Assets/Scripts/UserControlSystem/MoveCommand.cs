using UnityEngine;

public class MoveCommand : IMoveCommand
{
    public GameObject UnitPrefab => _unitPrefab;
    private GameObject _unitPrefab;

    public MoveCommand(GameObject unitPrefab = null)
    {
        _unitPrefab = unitPrefab;
    }
}
