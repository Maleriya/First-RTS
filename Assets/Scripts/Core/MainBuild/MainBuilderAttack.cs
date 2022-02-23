using UnityEngine;

public class MainBuilderAttack : CommandExecutorBase<IAttackCommand>
{
    public override void ExecuteSpecificCommand(IAttackCommand command)
    {
        Debug.Log($"This is Attack command to {command.Target}");
    }
}


