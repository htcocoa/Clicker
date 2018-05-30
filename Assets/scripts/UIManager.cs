using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text goldDisplayer;
    
    public Text goldPerClickDisplayer;
    public Text goldPerSecDisplayer;

    private void Update()
    {
        goldDisplayer.text = "GOLD: " + DataController.Instance.Gold;
        goldPerClickDisplayer.text = "GOLD PER CLICK: " + DataController.Instance.GoldPerClick;
        goldPerSecDisplayer.text = "GOLD PER SEC: " + DataController.Instance.GetGoldPerSec();
    }
}
