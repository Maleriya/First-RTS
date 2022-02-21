using System;
using Zenject;

public class StopCommandCommandCreator : CommandCreatorBase<IStopCommand>
{
    [Inject] private AssetsContext _context;
    protected override void classSpecificCommandCreation(Action<IStopCommand> creationCallback)
    {
        creationCallback?.Invoke(_context.Inject(new HoldCommand()));
    }
}

