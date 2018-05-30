using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour {

    public Animator anim;



    public void OnMouseDown()
    {
        
        DataController.Instance.Gold += DataController.Instance.GoldPerClick;

        anim.SetTrigger("OnClick");
    }
}
