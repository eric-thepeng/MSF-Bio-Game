using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour
{
    public int price = 0;
    float rotationSpeed = 30f;
    [SerializeField] private GameObject meshGameObject, uiGameObject;

    private void Start()
    {
        uiGameObject.GetComponent<TMP_Text>().text = "$" + price;
    }

    void Update()
    {
        meshGameObject.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnMouseUpAsButton()
    {
        if (Money.i.Spend(price))
        {
            LevelManager.i.PurchaseItem(gameObject);
        }
    }
    
    
}
