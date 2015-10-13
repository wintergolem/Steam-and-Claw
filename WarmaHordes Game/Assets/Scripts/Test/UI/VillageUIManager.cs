using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VillageUIManager : UIManager{

    public Text RecruitAmount;
    public Text RecruitValue;

    

    public enum Dialogs { Main, Recruit, Hostile , NoRecruits , Raided};
    public Dialogs ActiveDialog
    {
        get { return (Dialogs)iActiveDialog; }
        set { iActiveDialog = (int)value; }
    }

   #region Public Functions

    public void ToRecruit() 
    {
        if (GameManager.placeInfo.iRecruit > 0)
        {
            RecruitAmount.text = GameManager.placeInfo.iRecruit.ToString();
            RecruitValue.text = GameManager.placeInfo.iRecruitCost.ToString();
            TriggerNewPanel((int)Dialogs.Recruit);
        }
        else
            TriggerNewPanel((int)Dialogs.NoRecruits);
    }
    public void ToHostile() { TriggerNewPanel((int)Dialogs.Hostile); }
    public void ToMain() { TriggerNewPanel((int)Dialogs.Main); }
   
    public void AcceptRecruit()
    {
        GameManager.PrepareToTransferRecruits();
        ToMain();
    }
    public void BurnVillage()
    {
        GameManager.ToOverworldInfo.bBurnedVillage = true;
        GameManager.ChangeScene(GameManager.SceneDirectory.OverworldDevelop);
    }

    #endregion

    #region Private Functions

    void Start ()
    {
       
        base.Start();
        if (GameManager.placeInfo.bRaided)
            TriggerNewPanel((int)Dialogs.Raided);
    }
    void Update()
    {

    }
    void MainRecruitButtonClick()
    {
        TriggerNewPanel((int)Dialogs.Recruit);
    }

    #endregion
}
