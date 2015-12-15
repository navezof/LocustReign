using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    Card card;

    public static GameObject itemBeingDragged;
    
    public Vector3 startPosition;
    public Transform startParent;


    public void Awake()
    {
        card = GetComponent<Card>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!card.isDraggable)
            return;

        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!card.isDraggable)
            return;

        transform.position = Input.mousePosition;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        if (!card.isDraggable)
            return;

        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == startParent)
            transform.position = startPosition;
    }
}
