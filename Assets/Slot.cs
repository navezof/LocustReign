using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Slot : MonoBehaviour, IDropHandler {
    Line line;

    public int slotIndex;

    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return (transform.GetChild(0).gameObject);
            }
            return (null);
        }
    }

    void Start()
    {
        line = transform.parent.GetComponent<Line>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!item && DragHandeler.itemBeingDragged.GetComponent<Card>().owner == line.owner && DragHandeler.itemBeingDragged.GetComponent<Card>().type == line.type)
        {
            DragHandeler.itemBeingDragged.transform.SetParent(transform);
        }
    }
}
