using UnityEngine;
using UnityEngine.AI;
using System.Threading;

public class SoldierMove : CommandExecutorBase<IMoveCommand>
{
    [SerializeField] private UnitMovementStop _stop;
    [SerializeField] private Animator _animator;

    public override async void ExecuteSpecificCommand(IMoveCommand command)
    {
        Debug.Log($"{name} is moving to {command.Target}!");
        GetComponent<NavMeshAgent>().destination = command.Target;
        _animator.SetTrigger("Walk");
        await _stop;
        _animator.SetTrigger("Idle");
    }
}