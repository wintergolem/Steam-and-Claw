using UnityEngine;
using System;
using System.Collections;

public class UIManager : MonoBehaviour {

	// Use this for initialization
	protected void Start () 
    {
        if (aDialogs.Length > 0)
        {
            foreach (PanelCustom p in aDialogs)
                p.gameObject.SetActive(false);  //set all dialogs to inactive
            iActiveDialog = 0;    //ensure Active is Main
            aDialogs[iActiveDialog].gameObject.SetActive(true);  //Open dialog
        }
	}
	
	// Update is called once per frame
	void Update () {

    }

    #region variables

    public PanelCustom[] aDialogs; //set in Editor (Should match enum)

    public int iActiveDialog = 0;
    #endregion
    #region Public Functions

    public void TriggerNewPanel( int a_iDialogToChangeTo)
    {
        aDialogs[iActiveDialog].Close();                    //close panel
        iActiveDialog = a_iDialogToChangeTo;                      //set new active panel
        aDialogs[iActiveDialog].gameObject.SetActive(true); //open new panel
    }
    public void ToOverworld()
    {
        Application.LoadLevel(GameManager.SceneDirectory.OverworldDevelop.ToString());
    }


    #endregion

    #region Private Functions

    #endregion
}
