using UnityEngine;
public abstract class CommandExecutorBase<T> : MonoBehaviour, ICommandExecuter
{
	public void ExecuteCommand(object command) => ExecuteSpecificCommand((T)command);

	public abstract void ExecuteSpecificCommand(T command);
}
