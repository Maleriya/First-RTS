using System;
using System.Collections.Generic;
using UnityEngine;

public class CommandButtonsPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;
    [SerializeField] private CommandButtonsView _view;
    [SerializeField] private AssetsContext _context;

    private ISelectable _currentSelectable;
    
    void Start()
    {
        _selectable.OnSelected += onSelected;
        onSelected(_selectable.CurrentValue);
        _view.OnClick += onButtonClick;
    }

    private void onSelected(ISelectable selectable)
    {
        if (_currentSelectable == selectable)
            return;

        _currentSelectable = selectable;
        _view.Clear();

        if (selectable != null)
        {
            var commandExecutors = new List<ICommandExecuter>();
            commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecuter>());
            _view.MakeLayout(commandExecutors);
        }
    }
    private void onButtonClick(ICommandExecuter commandExecuter)
    {
        var unitProducer = commandExecuter as CommandExecutorBase<IProduceUnitCommand>;
        if (unitProducer != null)
        {
            unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommandHeir()));
            return;
        }

        var attacker = commandExecuter as CommandExecutorBase<IAttackCommand>;
        if (attacker != null)
        {
            attacker.ExecuteSpecificCommand(_context.Inject(new AttackCommand()));
            return;
        }
        var stopper = commandExecuter as CommandExecutorBase<IStopCommand>;
        if (stopper != null)
        {
            stopper.ExecuteSpecificCommand(_context.Inject(new HoldCommand()));
            return;
        }
        var mover = commandExecuter as CommandExecutorBase<IMoveCommand>;
        if (mover != null)
        {
            mover.ExecuteSpecificCommand(_context.Inject(new MoveCommand()));
            return;
        }
        var patroller = commandExecuter as CommandExecutorBase<IPatrolCommand>;
        if (patroller != null)
        {
            patroller.ExecuteSpecificCommand(_context.Inject(new PatrolCommand()));
            return;
        }

        throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(onButtonClick)}:" +
            $"Unknown type of commands executor: {commandExecuter.GetType().FullName}!");
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
