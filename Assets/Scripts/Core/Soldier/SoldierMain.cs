using System.Threading.Tasks;
using UnityEngine;

public class SoldierMain : MonoBehaviour, ISelectable, IAttackable, IDamageDealer, IAutomaticAttacker
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
    public IUnit _unit;

    [SerializeField] private Animator _animator;
    [SerializeField] private SoldierStop _stopCommand;

    public int Damage => _damage;

    [SerializeField] private int _damage = 25;

    public float VisionRadius => _visionRadius;
    [SerializeField] private float _visionRadius = 8f;

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

    public void RecieveDamage(int amount)
    {
        if (_health <= 0)
        {
            return;
        }
        _health -= amount;
        if (_health <= 0)
        {
            _animator.SetTrigger("PlayDead");
            Invoke(nameof(destroy), 1f);
        }
    }

    private async void destroy()
    {
        await _stopCommand.ExecuteSpecificCommand(new HoldCommand());
        Destroy(gameObject);
    }
}
