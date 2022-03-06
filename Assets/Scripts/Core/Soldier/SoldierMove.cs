using UnityEngine;
using UnityEngine.AI;
using System.Threading;

public class SoldierMove : CommandExecutorBase<IMoveCommand>
{
    [SerializeField] private UnitMovementStop _stop;
    [SerializeField] private Animator _animator;
    [SerializeField] private SoldierStop _soldierStop;

    public override async void ExecuteSpecificCommand(IMoveCommand command)
    {
        Debug.Log($"{name} is moving to {command.Target}!");
        GetComponent<NavMeshAgent>().destination = command.Target;
        _animator.SetTrigger(AnimationTypes.Walk);
        _soldierStop.CancellationTokenSource = new CancellationTokenSource();
        try
        {
            await _stop
            .WithCancellation
                (
                _soldierStop
                    .CancellationTokenSource
                    .Token
                );
        }
        catch
        {
            GetComponent<NavMeshAgent>().isStopped = true;
            GetComponent<NavMeshAgent>().ResetPath();
        }
        _soldierStop.CancellationTokenSource = null;
        _animator.SetTrigger(AnimationTypes.Idle);
    }
}