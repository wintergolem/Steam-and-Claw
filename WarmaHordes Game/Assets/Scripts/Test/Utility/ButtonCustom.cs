using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonCustom : MonoBehaviour
{

    public Text text;
    public bool bDisableAfterClick = false; //true = ensure that button can only be pressed once per panel load
    public PanelCustom Panel;

    //private variables
    bool bDisableTilPanelClose = false;
    Button button;

    //public functions
    public void ChangeText(string sNewText)
    {
        if (sNewText == null)
            Debug.Log("Null Text");
        text.text = sNewText;
    }


    //private functions
    void Start()
    {
        button = GetComponent<Button>();
        Panel.PanelClosing += new PanelClosingHandler(PanelClosing);
    }

    void Update()
    {
       
    }

    void PanelClosing()
    {
        if (bDisableTilPanelClose )
        {
            bDisableTilPanelClose = true;
            button.interactable = true; //should only affect button, button will be active next panel enable
        }
    }

}
