using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragableUI : MonoBehaviour,
               IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector3 dragOffset = Vector2.zero;
    Vector2 limits = Vector2.zero;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Camera cam = Camera.main;
        dragOffset = cam.ScreenToWorldPoint(eventData.position) - transform.position;
        limits = transform.parent.GetComponent<RectTransform>().rect.max;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Camera cam = Camera.main;
        transform.position = cam.ScreenToWorldPoint(eventData.position) - dragOffset;
        var p = transform.localPosition;
        if (p.x < -limits.x) { p.x = -limits.x; }
        if (p.x > limits.x) { p.x = limits.x; }
        if (p.y < -limits.y) { p.y = -limits.y; }
        if (p.y > limits.y) { p.y = limits.y; }
        transform.localPosition = p;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragOffset = Vector2.zero;
    }
}
