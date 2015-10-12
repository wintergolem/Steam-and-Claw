using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public delegate void PanelClosingHandler();

public class PanelCustom : MonoBehaviour {

    public Text tPlaceName;

    //public functions
    public event PanelClosingHandler PanelClosing;

    public void Close()
    {
        PanelClosing();
        gameObject.SetActive(false);
    }

	void Start () {

	}
	
	
	void Update () {
	
	}

    void OnEnable()
    {
        tPlaceName.text = GameManager.placeInfo.sName;
    }
}
