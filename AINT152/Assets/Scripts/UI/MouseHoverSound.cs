using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MouseHoverSound : MonoBehaviour, IPointerEnterHandler
{
    public UnityEvent onHover;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        onHover.Invoke();
    }
}
