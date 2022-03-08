using System.Threading.Tasks;
using UnityEngine;

public class SetRallyPointCommandExecutor : CommandExecutorBase<ISetRallyPointCommand>
{
	public override async Task ExecuteSpecificCommand(ISetRallyPointCommand command)
	{
		GetComponent<MainBuilding>().RallyPoint = command.RallyPoint;
		Debug.Log($"command.RallyPoint {command.RallyPoint}");
	}
}
