using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Cemetary : MonoBehaviour, IDropHandler {

    public Line line;
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
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (DragHandeler.itemBeingDragged == null)
            return;
        Card card = DragHandeler.itemBeingDragged.GetComponent<Card>();
        if (card.owner == line.GetOwner())
        {
            DragHandeler.itemBeingDragged.GetComponent<Card>().Remove();
        }
    }
}
