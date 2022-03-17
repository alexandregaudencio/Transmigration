using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragManager : MonoBehaviour, IEndDragHandler, IBeginDragHandler, IDragHandler
{

    /*[SerializeField] */private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform lastParent;
    private Vector3 lastPosition = Vector3.zero;

    private void Awake()
    {
        //canvas = GetComponentInParent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

    }

    

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (canvas == null)
            canvas = GetComponentInParent<Canvas>();
        lastParent = transform.parent;
        lastPosition = transform.position;

        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta /canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerDrag.transform.parent == lastParent)
            transform.position = lastPosition;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

    }





}
