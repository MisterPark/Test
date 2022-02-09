using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_DragMove : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    private Vector2 startPoint;
    private Vector2 beginPoint;
    private Vector2 offset;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPoint = transform.position;
        beginPoint = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        offset = eventData.position - beginPoint;
        transform.position = startPoint + offset;
    }
}
