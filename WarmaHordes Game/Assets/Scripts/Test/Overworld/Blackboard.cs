using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Blackboard : MonoBehaviour {

    public static Blackboard instance;

    public GameObject panel;

    public bool bEnteringTown;

    public bool bEnteredTown;

    //Functions
    public void EnterTown()
    {
        panel.SetActive(true);
        bEnteredTown = true;
        bEnteringTown = false;
    }

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if( !panel.activeSelf && bEnteredTown)
        {
            bEnteredTown = false;
        }

    }

}
