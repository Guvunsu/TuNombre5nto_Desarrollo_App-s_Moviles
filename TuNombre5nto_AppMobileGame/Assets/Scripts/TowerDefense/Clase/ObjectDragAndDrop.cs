using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class ObjectDragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public bool dragOnSurfaces = true;

    private GameObject m_DragingIcon;
    private RectTransform m_dragingPlane;
    public void OnBeginDrag(PointerEventData eventData)
    {
        var canvas = FindInParents<Canvas>(gameObject);
        if (canvas == null)
        {
            return;
        }
        // we have clicked something that can be dragged
        // what we want to do is create an icon for this
        m_DragingIcon = new GameObject("icon");
        m_DragingIcon.transform.SetParent(canvas.transform, false);
        m_DragingIcon.transform.SetAsLastSibling();

        var image = m_DragingIcon.AddComponent<Image>();
        image.sprite = GetComponent<Image>().sprite;
        image.SetNativeSize();

        if (dragOnSurfaces)
        {
            m_dragingPlane = transform as RectTransform;
        }
        else
            m_dragingPlane = canvas.transform as RectTransform;

        SetDraggedPosition(eventData);
        // cabiar el icono que indica que objeto estamos arrastrando a la pantalla 
    }
    public void OnDrag(PointerEventData data)
    {
        if (m_DragingIcon != null)
        {
            SetDraggedPosition(data);
        }
    }
    private void SetDraggedPosition(PointerEventData data)
    {
        if (dragOnSurfaces && data.pointerEnter != null && data.pointerEnter.transform as RectTransform != null)
        {
            m_dragingPlane = data.pointerEnter.transform as RectTransform;
            var rt = m_DragingIcon.GetComponent<RectTransform>();
            Vector3 globalMousePos;
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_dragingPlane, data.position, data.pressEventCamera, out globalMousePos))
            {
                rt.position = globalMousePos;
                rt.position = m_dragingPlane.position;
            }
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (m_DragingIcon != null)
        {
            PlacementSystem.instance.CreateObject();
            Destroy(m_DragingIcon);

        }
    }
    static public T FindInParents<T>(GameObject go) where T : Component
    {
        if (go == null) return null;
        var comp = go.GetComponent<T>();

        if (comp != null) return comp;

        Transform t = go.transform.parent;
        while (t != null && comp == null)
        {
            comp = t.gameObject.GetComponent<T>();
            t = t.parent;
        }
        return comp;
    }
}
