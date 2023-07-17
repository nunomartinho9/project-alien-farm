using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image image;
    public Transform ParentAfterDrag { get; set; }
    public Item Item { get; private set;  }
    private int count = 1;

    public int Count
    {
        get => count;
        set => count = value;
    }
    [SerializeField] private Text countText;
    private void Start()
    {
        if (Item == null) return;
        IntializeItem(Item);
    }

    public void IntializeItem(Item newItem)
    {
        Item = newItem;
        image.sprite = newItem.sprite;
        RefreshCount();
    }

    public void RefreshCount()
    {
        countText.text = Count.ToString();
        bool textActive = Count > 1;
        countText.gameObject.SetActive(textActive);
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        ParentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(ParentAfterDrag);
        image.raycastTarget = true;
    }
}
