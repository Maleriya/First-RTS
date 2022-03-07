using UnityEngine;
using UnityEngine.AI;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Collections;

public class SoldierMove : CommandExecutorBase<IMoveCommand>
{
    [SerializeField] private UnitMovementStop _stop;
    [SerializeField] private Animator _animator;
    [SerializeField] private SoldierStop _soldierStop;

    public override async Task ExecuteSpecificCommand(IMoveCommand command)
    {
        Debug.Log($"{name} is moving to {command.Target}!");
        GetComponent<NavMeshAgent>().destination = command.Target;
        _animator.SetTrigger(AnimationTypes.Walk);
        _soldierStop.CancellationTokenSource = new CancellationTokenSource();
        if (_stop != null)
        {
            {
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
                catch (Exception ex)
                {
                    Debug.Log($"{name} is stop to {ex.Message}!");
                    GetComponent<NavMeshAgent>().isStopped = true;
                    GetComponent<NavMeshAgent>().ResetPath();
                }
            }
        }
        else
        {

        }
        _soldierStop.CancellationTokenSource = null;
        Debug.Log($"{name} is stop to SetTrigger(AnimationTypes.Idle!");
        _animator.SetTrigger(AnimationTypes.Idle);
    }
}