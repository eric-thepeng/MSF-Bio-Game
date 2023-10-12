using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    static LevelManager instance = null;
    public static LevelManager i
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LevelManager>();
            }
            return instance;
        }
    }
    
    [Serializable]
    public class Level
    {
        public int newAge;
        public int newMoney;
        public List<GameObject> newItems;
    }

    public List<Level> allLevels;
    private int currentLevelIndex = 0;
    private int currentAge;

    private List<GameObject> displayingItems;

    public Vector3 baseShopItemLocation;
    public Vector3 baseBagItemLocation;

    private List<GameObject> bagItems;

    private void Start()
    {
        bagItems = new List<GameObject>();
        displayingItems = new List<GameObject>();
        DisplayCurrentLevel();
    }

    public void NextLevel()
    {
        if(currentLevelIndex>=allLevels.Count) return;
        DeleteDisplayingItems();
        currentLevelIndex++;
        DisplayCurrentLevel();
    }



    public void PurchaseItem(GameObject go)
    {
        int i = bagItems.Count;
        go.transform.position = baseBagItemLocation + new Vector3(2,0,0) * (i%7) + new Vector3(0,2,0) * (int)(i/7);
        bagItems.Add(go);
    }
    
    
    
    

    void DisplayCurrentLevel()
    {
        DisplayNewItems();
        Money.i.Gain(allLevels[currentLevelIndex].newMoney);
    }

    void DeleteDisplayingItems()
    {
        foreach (GameObject go in displayingItems)
        {
            Destroy(go);
        }

        displayingItems = new List<GameObject>();
    }

    void DisplayNewItems()
    {
        displayingItems = new List<GameObject>();
        Level currentLevel = allLevels[currentLevelIndex];
        for(int i = 0; i<currentLevel.newItems.Count; i++)
        {
            GameObject go = currentLevel.newItems[i];
            displayingItems.Add(go);
            go.transform.position = baseShopItemLocation + new Vector3(2,0,0) * (i%7) + new Vector3(0,2,0) * (int)(i/7);
        }
    }
    


}
