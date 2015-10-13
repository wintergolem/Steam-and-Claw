using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonCustom : MonoBehaviour
{

    public Text text;
    public PanelCustom Panel;

    //private variables

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
    }

    void Update()
    {
       
    }


}
