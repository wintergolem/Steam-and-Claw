using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OverworldUIManager : UIManager
{
    #region Variables

    public Text PartySizeValue;

    #endregion

    #region Functions

    void Update()
    {
        PartySizeValue.text = GameManager.partyManager.iCurrentPartySize.ToString();
    }

    #endregion
}
