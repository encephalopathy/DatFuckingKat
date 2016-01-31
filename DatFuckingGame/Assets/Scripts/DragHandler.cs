using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    Transform startParent;
    Transform oldParent;
    Transform canvas;
    Transform originalParent;


    public void Start()
    {
        originalParent = transform.parent;
    }

    public void SetToOriginalParent()
    {
        transform.SetParent(originalParent);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("On BeginDrag");
        itemBeingDragged = gameObject;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        canvas = GameObject.FindGameObjectWithTag("UI Canvas").transform;
        oldParent = transform.parent;
        transform.SetParent(canvas);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("On end Drag");
        //Debug.Log(transform.parent + " == " + canvas);
        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == canvas)
        {
            transform.SetParent(oldParent);
        }
    }
}