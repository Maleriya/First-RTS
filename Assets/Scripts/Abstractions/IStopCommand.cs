using UnityEngine;

public interface IStopCommand : ICommand
{
    GameObject UnitPrefab { get; }
}
