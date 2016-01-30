﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
namespace Assets.Scripts
{
    public class Slot : MonoBehaviour, IDropHandler {
        public GameObject item
        {
            get
            {
                if (transform.childCount > 0)
                {
                    return transform.GetChild(0).gameObject;
                }
                return null;
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (!item)
            {
                DragHandler.itemBeingDragged.transform.SetParent(transform);
            }
        }
    }
}
