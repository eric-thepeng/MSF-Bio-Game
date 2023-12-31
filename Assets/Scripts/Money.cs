using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    
    static Money instance = null;
    public static Money i
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Money>();
            }
            return instance;
        }
    }

    private int age = 100;
    
    public int amount;
    [SerializeField] private GameObject uiGameObject;

    public bool Spend(int spendAmount)
    {
        if (spendAmount > amount) return false;
        amount -= spendAmount;
        UpdateUI();
        return true;
    }

    public int Gain(int gainAmount)
    {
        amount += gainAmount;
        UpdateUI();
        return amount ;
    }

    void UpdateUI()
    {
        uiGameObject.GetComponent<TMP_Text>().text = "Pocket Money \n $ " + amount + "\n Age: " + age;
        //print("we have money: " + amount);
    }

    public void ChangeAge(int newAge)
    {
        age = newAge;
        UpdateUI();
    }
}
