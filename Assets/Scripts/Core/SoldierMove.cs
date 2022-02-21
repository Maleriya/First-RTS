using UnityEngine;

public class SoldierMove : CommandExecutorBase<IMoveCommand>
{
    public override void ExecuteSpecificCommand(IMoveCommand command)
    {
        Debug.Log("This is Move command");
    }
}
