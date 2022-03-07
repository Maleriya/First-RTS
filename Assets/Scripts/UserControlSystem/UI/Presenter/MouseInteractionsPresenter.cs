using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class MouseInteractionsPresenter : MonoBehaviour
{
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;

    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private AttackableValue _attackablesRMB;
    [SerializeField] private Transform _groundTransform;

    private Plane _groundPlane;

    [Inject]
    private void Init()
    {
        _groundPlane = new Plane(_groundTransform.up, 0);

        // берем поток всех кадров, где клик не на UI
        var nonBlockedByUiFramesStream = Observable.EveryUpdate().Where(_ => !_eventSystem.IsPointerOverGameObject());

        // разделим на два потока - ЛКМ и ПКМ
        var leftClickStream = nonBlockedByUiFramesStream.Where(_ => Input.GetMouseButtonDown(0));
        var rightClickStream = nonBlockedByUiFramesStream.Where(_ => Input.GetMouseButtonDown(1));

        // разделяем еще на лучи от ЛКМ и ПКМ на экране
        var lmbRays = leftClickStream.Select(_ => _camera.ScreenPointToRay(Input.mousePosition));
        var rmbRays = rightClickStream.Select(_ => _camera.ScreenPointToRay(Input.mousePosition));

        // делаем выборку из пересечений с лучом
        var lmbHitsStream = lmbRays.Select(ray => Physics.RaycastAll(ray));
        // здесь еще сохраняем еще и сам луч
        var rmbHitsStream = rmbRays.Select(ray => (ray, Physics.RaycastAll(ray)));

        // подписываемся на выборку
        lmbHitsStream.Subscribe(hits =>
        {
            if(weHit<ISelectable>(hits, out var selectable))
            {
                _selectedObject.SetValue(selectable);
            }
        });

        rmbHitsStream.Subscribe((ray, hits) =>
        {
            if (weHit<IAttackable>(hits, out var attackable))
            {
                _attackablesRMB.SetValue(attackable);            
            }
            else if (_groundPlane.Raycast(ray, out var enter))
            {
                _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
            }
        });
    }

    private bool weHit<T>(RaycastHit[] hits, out T result) where T : class
    {
        result = default;
        if (hits.Length == 0)
        {
            return false;
        }
        result = hits
            .Select(hit => hit.collider.GetComponentInParent<T>())
            .Where(c => c != null)
            .FirstOrDefault();
        return result != default;
    }
}