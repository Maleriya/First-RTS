using UnityEngine;

public interface IAttackCommand : ICommand
{
    GameObject UnitPrefab { get; }
}
