using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NodeSlot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private float minWidth, minHeight;
    private LayoutElement layoutElement;

    public string correctValue;

    void Awake()
    {
        layoutElement = GetComponent<LayoutElement>();

        minWidth = layoutElement.minWidth; 
        minHeight = layoutElement.minHeight;
    }

    public bool CheckAnswer()
    {
        if (gameObject.transform.childCount == 0)
            return false;

        string answer = gameObject.transform.GetChild(0).GetComponent<DraggableNode>().value;

        return answer == correctValue;
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DraggableNode draggableNode = dropped.GetComponent<DraggableNode>();

        // Basically means you're trying to drag the item to a node slot
        // that already contains a node. This code makes them swap with
        // each others parent.
        if (transform.childCount != 0)
        {
            transform.GetChild(0).SetParent(draggableNode.parentAfterDrag);
            LayoutRebuilder.ForceRebuildLayoutImmediate(draggableNode.parentAfterDrag.GetComponent<RectTransform>());
        }

        draggableNode.parentAfterDrag = transform;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (DraggableNode.current != null)
        {
            Rect rect = DraggableNode.current.GetComponent<RectTransform>().rect;

            layoutElement.minWidth = rect.width;
            layoutElement.minHeight = rect.height;
            LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        layoutElement.minWidth = minWidth;
        layoutElement.minHeight = minHeight;
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }
}
