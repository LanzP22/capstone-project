using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableNode : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    [HideInInspector] public string value;
    [HideInInspector] public Transform defaultParent;
    [HideInInspector] public Transform parentAfterDrag;

    void Awake()
    {
        defaultParent = transform.parent;
        value = GetComponentInChildren<TextMeshProUGUI>().text;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        LayoutRebuilder.ForceRebuildLayoutImmediate(parentAfterDrag.GetComponent<RectTransform>());
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.SetParent(defaultParent);
        LayoutRebuilder.ForceRebuildLayoutImmediate(parentAfterDrag.GetComponent<RectTransform>());
    }
}
