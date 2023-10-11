using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    [SerializeField] UnityEvent clickEvent;
    private void OnMouseUpAsButton()
    {
        clickEvent.Invoke();
    }
}
