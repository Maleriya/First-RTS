using UnityEngine;

public class SoldierStop : CommandExecutorBase<IStopCommand>
{
    public override void ExecuteSpecificCommand(IStopCommand command)
    {
        Debug.Log("This is Stop command");
    }
}
