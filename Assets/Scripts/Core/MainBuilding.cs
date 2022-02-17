using UnityEngine;

public class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;

    [SerializeField] private Transform _unitsParent;  
    [SerializeField] private float _maxHealth;
    [SerializeField] private Sprite _icon;
    private float _health;
    [SerializeField] private Material _material;

    public MainBuilding()
    {
        _maxHealth = 1000;
        _health = _maxHealth;
        //_material = GetComponentInChildren<Renderer>().material;
    }

    public void EnterOutline()
    {
        _material?.SetFloat("_Outline", 0.02f);
    }

    public void ExitOutline()
    {
        _material?.SetFloat("_Outline", 0.0f);
    }

    public override void ExecuteSpecificCommand(IProduceUnitCommand command)
    {
       Instantiate(command.UnitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
    }
}
