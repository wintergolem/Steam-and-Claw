using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Party : MonoBehaviour {

    public int iMaxPartySize = 35;
    public int iCurrentPartySize = 0;
    public Text text;

	void Start () 
    {
        PartyChange(15);
	}
	
	void Update () 
    {
	    
	}

    //Called when we want to add to party, currently only done through cheats and towns
    public void AddToParty(int iAmount)
    {
        //check that the number is positive
        if (iAmount <= 0)
            Debug.LogError("Attempting to add 0 or fewer members to a party");
        //check that current + amount <= max
        if (iCurrentPartySize + iAmount <= iMaxPartySize)
            Debug.LogError("Attempting to add too many members to a party");
        //Seems to check out
        PartyChange(iAmount);
    }

    //this function should be called anytime that party size is changed
    void PartyChange(int iAmount)
    {
        iCurrentPartySize += iAmount;
        text.text = "Party Size: " + iCurrentPartySize.ToString();
    }
}
