using UnityEngine;
using Zenject;

public class MainBuildingCommandQueue : MonoBehaviour, ICommandsQueue
{
	[Inject] CommandExecutorBase<IProduceUnitCommand> _produceUnitCommandExecutor;
	[Inject] CommandExecutorBase<ISetRallyPointCommand> _setRallyPointExecutor;

	public ICommand CurrentCommand => default;
	public void Clear() { }

	public async void EnqueueCommand(object command)
	{
		if (command is IProduceUnitCommand)
			await _produceUnitCommandExecutor.ExecuteSpecificCommand(command as IProduceUnitCommand);
		else
			if (command is ISetRallyPointCommand)
			await _setRallyPointExecutor.ExecuteSpecificCommand(command as ISetRallyPointCommand);
	}
}
