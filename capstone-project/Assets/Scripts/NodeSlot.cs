using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NodeSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DraggableNode draggableNode = dropped.GetComponent<DraggableNode>();

        // Basically means you're trying to drag the item to a node slot
        // that already contains a node. This code makes them swap with
        // each others parent.
        if (transform.childCount != 0)
            transform.GetChild(0).SetParent(draggableNode.parentAfterDrag);

        draggableNode.parentAfterDrag = transform;
    }
}
