using UnityEngine;
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
            Debug.Log("On Drop");
            if (!item) {

                GetComponent<AudioSource>().Play();
                DragHandler.itemBeingDragged.transform.SetParent(transform);
            }
        }
    }
}
