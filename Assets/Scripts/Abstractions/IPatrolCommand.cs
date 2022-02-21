using UnityEngine;

public interface IPatrolCommand : ICommand
{
    GameObject UnitPrefab { get; }
}
