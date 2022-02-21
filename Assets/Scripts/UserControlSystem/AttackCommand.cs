using UnityEngine;

public class AttackCommand : IAttackCommand
{
    public GameObject UnitPrefab => _unitPrefab;
    private GameObject _unitPrefab;

    public AttackCommand(GameObject unitPrefab = null)
    {
        _unitPrefab = unitPrefab;
    }
}
