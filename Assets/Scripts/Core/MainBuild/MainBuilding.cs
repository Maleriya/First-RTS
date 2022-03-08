using System.Threading.Tasks;
using UnityEngine;

public class MainBuilding : MonoBehaviour, ISelectable, IAttackable
{
    public Transform PivotPoint => _pivotPoint;
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;

    public Vector3 RallyPoint { get; set; }

    [SerializeField] private Transform _unitsParent;  
    [SerializeField] private float _maxHealth;
    [SerializeField] private Sprite _icon;
    private float _health;
    private Material _material;
    private Transform _pivotPoint;
    public MainBuilding()
    {
        _maxHealth = 1000;
        _health = _maxHealth;       
    }

    private void Awake()
    {
        _material = GetComponentInChildren<Renderer>().material;
        _pivotPoint = transform;
    }

    public void EnterOutline()
    {
        _material?.SetFloat("_Outline", 0.02f);
    }

    public void ExitOutline()
    {
        _material?.SetFloat("_Outline", 0.0f);
    }
}
