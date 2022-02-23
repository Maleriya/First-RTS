using System.Threading;
using UnityEngine;

public class SoldierStop : CommandExecutorBase<IStopCommand>
{
	public CancellationTokenSource CancellationTokenSource { get; set; }

	public override void ExecuteSpecificCommand(IStopCommand command)
	{
		Debug.Log("This is Stop command");
		CancellationTokenSource?.Cancel();
	}
}
