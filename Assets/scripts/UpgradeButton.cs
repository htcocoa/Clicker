using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour {

    public Text upgradeDisplyer;

    public string upgradeName;

    [HideInInspector]
    public int goldByUpgrade;

    public int startGoldByUpgrade = 1;

    public float costPow = 3.14f;

    [HideInInspector]
    public int level = 1;

    [HideInInspector]
    public int currentCost = 1;

    public int startCurrentCost = 1;

    public float upgradePow = 1.07f;

    private void Start()
    {
        DataController.Instance.LoadUpgradeButton(this);
        UpdateUI();

    }

    public void PurchaseUpgrade()
    {
        if(DataController.Instance.Gold >= currentCost)
        {
            DataController.Instance.Gold -= currentCost;
            level++;
            DataController.Instance.GoldPerClick += goldByUpgrade;
            UpdateUpgrade();
            DataController.Instance.SaveUpgradeButton(this);

        }
    }

    public void UpdateUpgrade()
    {
        goldByUpgrade = startGoldByUpgrade * (int)Mathf.Pow(upgradePow, level);
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
        UpdateUI();
    }
    public void UpdateUI()
    {
        upgradeDisplyer.text = upgradeName + "\nCost: " + currentCost + "\nLevel: " + level +  "\n Next GoldPerClick: " + goldByUpgrade;
    }
}
