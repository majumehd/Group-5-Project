using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour,IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] public Canvas canvas;
    static public GameObject itemBeingDragged;
    static public ItemInfo tmpInfo;
    static public RectTransform rectTransform;
   
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        Destroy(itemBeingDragged);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        itemBeingDragged = Instantiate(gameObject);

        itemBeingDragged.transform.SetParent(canvas.transform, true);
        itemBeingDragged.transform.localScale = new Vector3(1, 1, 1);
        itemBeingDragged.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);

        RectTransform tmpRT = gameObject.GetComponent<RectTransform>();

        rectTransform = itemBeingDragged.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(tmpRT.sizeDelta.x, tmpRT.sizeDelta.y);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
        tmpInfo = GetComponent<ItemInfo>();
        itemBeingDragged.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if(rectTransform!=null)
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
}