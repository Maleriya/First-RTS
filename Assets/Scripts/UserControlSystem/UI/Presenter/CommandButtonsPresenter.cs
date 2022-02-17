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

        _ = unitProducer ?? throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(onButtonClick)}:" +
            $"Unknown type of commands executor: {commandExecuter.GetType().FullName}!");
        
        unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommand()));
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
