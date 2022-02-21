using UnityEngine;

public interface IMoveCommand : ICommand
{
    GameObject UnitPrefab { get; }
}
