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
        if (transform.childCount != 0) 
            return;

        GameObject dropped = eventData.pointerDrag;
        DraggableNode draggableNode = dropped.GetComponent<DraggableNode>();
        draggableNode.parentAfterDrag = transform;
    }
}
