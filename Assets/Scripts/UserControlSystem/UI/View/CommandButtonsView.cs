using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CommandButtonsView : MonoBehaviour
{
    public Action<ICommandExecuter> OnClick;

    [SerializeField] private GameObject _attackButton;
    [SerializeField] private GameObject _moveButton;
    [SerializeField] private GameObject _patrolButton;
    [SerializeField] private GameObject _stopButton;
    [SerializeField] private GameObject _produceUnitButton;

    private Dictionary<Type, GameObject> _buttonsByExecutorType;

    void Start()
    {
        _buttonsByExecutorType = new Dictionary<Type, GameObject>();
        _buttonsByExecutorType.Add(typeof(CommandExecutorBase<IAttackCommand>), _attackButton);
        _buttonsByExecutorType.Add(typeof(CommandExecutorBase<IMoveCommand>), _moveButton);
        _buttonsByExecutorType.Add(typeof(CommandExecutorBase<IPatrolCommand>), _patrolButton);
        _buttonsByExecutorType.Add(typeof(CommandExecutorBase<IStopCommand>), _stopButton);
        _buttonsByExecutorType.Add(typeof(CommandExecutorBase<IProduceUnitCommand>), _produceUnitButton);
    }

    public void MakeLayout(IEnumerable<ICommandExecuter> commandExecuters)
    {
        foreach (var currentExecutor in commandExecuters)
        {
            var buttonGameObject = _buttonsByExecutorType
                .Where(type => type
                                .Key
                                .IsAssignableFrom(currentExecutor.GetType())
                      )
                .First()
                .Value;
            buttonGameObject.SetActive(true);
            var button = buttonGameObject.GetComponent<Button>();
            button.onClick.AddListener(() => OnClick?.Invoke(currentExecutor));
        }
    }

    public void Clear()
    {
        foreach (var keyValuePair in _buttonsByExecutorType)
        {
            keyValuePair.Value.GetComponent<Button>().onClick.RemoveAllListeners();
            keyValuePair.Value.SetActive(false);
        }
    }
}
