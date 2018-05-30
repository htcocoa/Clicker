using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour {

    public Text itemDisplayer;
  

    public CanvasGroup canvasGroup;

    public Slider slider;
    public string itemName;

    [HideInInspector]
    public int level = 0;


    public int currentCost;
    public int startCurrentCost = 1;

    [HideInInspector]
    public int goldPerSec;
    public int startGoldPerSec = 1;
    public float costPow = 3.14f;
    public float upgradePow = 1.07f;

    [HideInInspector]
    public bool isPurchased = false;


    private void Start()
    {
        DataController.Instance.LoadItemButton(this);
        StartCoroutine("AddGoldLoop");
        UpdateUI();

    }
    public void PurchaseItem()
    {
        if(DataController.Instance.Gold >= currentCost)
        {
            isPurchased = true;
            DataController.Instance.Gold -= currentCost;
            level++;
            UpdateItem();
            

            DataController.Instance.SaveItemButton(this);

        }
    }
    private void Update()
    {
        UpdateUI();
    }
    IEnumerator AddGoldLoop()
    {
        while (true)
        {
            if (isPurchased)
            {
                DataController.Instance.Gold += goldPerSec;
                 
            }
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void UpdateItem()
    {
        goldPerSec = goldPerSec + startGoldPerSec * (int)Mathf.Pow(upgradePow, level);
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
    }
    public void UpdateUI()
    {
        itemDisplayer.text = itemName + "\nLevel: " + level + "\nCost: " + currentCost + "\nGold Per Sec: " + goldPerSec;
        slider.minValue = 0;
        slider.maxValue = currentCost;

        slider.value = DataController.Instance.Gold;

        if(isPurchased)
        {
            canvasGroup.alpha = 1.0f; 
        }
        else
        {
            canvasGroup.alpha = 0.6f;
        }
        

    }
}
