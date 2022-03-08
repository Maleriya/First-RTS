using System.Threading.Tasks;
using UnityEngine;

public class SoldierPatrol : CommandExecutorBase<IPatrolCommand>
{
    public override async Task ExecuteSpecificCommand(IPatrolCommand command)
    {
        Debug.Log("This is Patrol command");
    }
}
