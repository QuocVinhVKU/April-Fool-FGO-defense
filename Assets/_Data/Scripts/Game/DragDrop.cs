using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Canvas canvas;
    private RectTransform recTranTowerUI;
    public GameObject ok;
    private Vector2 currentRec;

    void Awake()
    {
        recTranTowerUI = GetComponent<RectTransform>();
        currentRec = recTranTowerUI.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }
    public void OnDrag(PointerEventData eventData)
    {
        recTranTowerUI.anchoredPosition += eventData.delta;
        Debug.Log(currentRec);
        Debug.Log(recTranTowerUI.position);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        currentRec = ok.transform.position;
        recTranTowerUI.position = currentRec;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
    }

}
