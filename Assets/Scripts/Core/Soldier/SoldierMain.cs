using UnityEngine;

public class SoldierMain : CommandExecutorBase<IAttackCommand>, ISelectable, IAttackable
{
    public Transform PivotPoint => _pivotPoint;
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;

    [SerializeField] private Transform _unitsParent;
    [SerializeField] private float _maxHealth;
    [SerializeField] private Sprite _icon;
    private float _health;
    private Material _material;
    private Transform _pivotPoint; 
    public SoldierMain()
    {
        _maxHealth = 500;
        _health = _maxHealth;  
    }

    private void Awake()
    {
        _material = GetComponentInChildren<Renderer>().material;
        _pivotPoint = transform;
        _unitsParent = _unitsParent ?? GetComponentInParent<Transform>();
    }

    public void EnterOutline()
    {
        _material?.SetFloat("_Outline", 0.02f);
    }

    public void ExitOutline()
    {
        _material?.SetFloat("_Outline", 0.0f);
    }

    public override void ExecuteSpecificCommand(IAttackCommand command)
    {
        Debug.Log($"This is Attack command to {command.Target}");
    }
}
