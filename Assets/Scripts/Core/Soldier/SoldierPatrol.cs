using UnityEngine;

public class SoldierPatrol : CommandExecutorBase<IPatrolCommand>
{
    public override void ExecuteSpecificCommand(IPatrolCommand command)
    {
        Debug.Log("This is Patrol command");
    }
}
