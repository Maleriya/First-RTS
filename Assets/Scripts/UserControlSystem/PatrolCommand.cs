using UnityEngine;

public class PatrolCommand : IPatrolCommand
{
    public GameObject UnitPrefab => _unitPrefab;
    private GameObject _unitPrefab;

    public PatrolCommand(GameObject unitPrefab = null)
    {
        _unitPrefab = unitPrefab;
    }
}
