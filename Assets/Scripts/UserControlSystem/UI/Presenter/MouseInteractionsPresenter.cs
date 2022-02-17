using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInteractionsPresenter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectableObject;
    [SerializeField] private EventSystem _eventSystem;

    private void Update()
    {
        if (!Input.GetMouseButtonUp(0) || _eventSystem.IsPointerOverGameObject())
            return;

        var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));

        if (hits.Length == 0)
            return;

        ISelectable selectable = hits
            .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
            .Where(c => c != null)
            .FirstOrDefault();

        _selectableObject.SetValue(selectable);
    }
}
