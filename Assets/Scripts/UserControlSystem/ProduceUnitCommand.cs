using UnityEngine;

public class ProduceUnitCommand : IProduceUnitCommand
{
    public GameObject UnitPrefab => _unitPrefab;
    [InjectAsset("Chomper Variant")] private GameObject _unitPrefab;

    public ProduceUnitCommand(GameObject unitPrefab = null)
    {
        _unitPrefab = unitPrefab;
    }
}
