using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class SoldierStop : CommandExecutorBase<IStopCommand>
{
	public CancellationTokenSource CancellationTokenSource { get; set; }

	public override async Task ExecuteSpecificCommand(IStopCommand command)
	{
		Debug.Log("This is Stop command");
		CancellationTokenSource?.Cancel();
	}
}
