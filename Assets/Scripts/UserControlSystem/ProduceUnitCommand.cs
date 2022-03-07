using UnityEngine;
using Zenject;

public class ProduceUnitCommand : IProduceUnitCommand
{
    [Inject(Id = "Chrom")] public string UnitName { get; }
    [Inject(Id = "Chrom")] public Sprite Icon { get; }
    [Inject(Id = "Chrom")] public float ProductionTime { get; }

    public GameObject UnitPrefab => _unitPrefab;
    [InjectAsset("Chomper Variant")] private GameObject _unitPrefab;
}
