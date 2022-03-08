using System.Threading.Tasks;
using UnityEngine;

public class MainBuilderAttack : CommandExecutorBase<IAttackCommand>
{
    public override async Task ExecuteSpecificCommand(IAttackCommand command)
    {
        Debug.Log($"This is Attack command to {command.Target}");
    }
}


