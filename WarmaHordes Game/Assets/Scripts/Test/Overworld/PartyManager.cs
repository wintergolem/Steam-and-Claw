using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PartyManager
{

    #region Public Variables
    public int iMaxPartySize = 35;
    public int iCurrentPartySize = 1;   //add get set that blocks outside set
    public int iPartyGold
    {
        get
        {
            return m_iPartyGold;
        }
        set { Debug.LogError("Cannot set iPartyGold variable - Use PartyManager.AddGold instead"); }
    }
    #endregion

    #region Private Variables
    int m_iPartyGold = 50;
    const int MAX_GOLD = 1000000;       //current max 1 million gold
    #endregion

    //Called when we want to add to party, currently only done through cheats and towns
    public void AddToParty(int iAmount)
    {
        //check that the number is positive
        if (iAmount <= 0)
            Debug.LogError("Attempting to add 0 or fewer members to a party");
        //check that current + amount <= max
        if (iCurrentPartySize + iAmount > iMaxPartySize)
            Debug.LogError("Attempting to add too many members to a party");
        //Seems to check out
        PartyChange(iAmount);
    }

    //this function should be called anytime that party size is changed
    void PartyChange(int iAmount)
    {
        iCurrentPartySize += iAmount;
    }

    //this function is used to add to gold value
    public void AddGold(int a_iAmount)
    {
        //check to ensure amount is valid
        if (a_iAmount <= 0)
        {
            Debug.LogError("Attempting to add zero or negative number to gold total");
            return;
        }
        if (a_iAmount + m_iPartyGold > MAX_GOLD)
        {
            Debug.LogError("Attempting to add too much gold $" + a_iAmount.ToString());
            return;
        }
    }

    public int SpendGold( int a_iAmount, bool a_bRunChecks = true)
    {
        //if no checks are required (unusual) just lose the gold (lower cap is still 0)
        if( !a_bRunChecks )
        {
            m_iPartyGold = a_iAmount > m_iPartyGold ? 0 : m_iPartyGold - a_iAmount;
            return 0;
        }
        else
        {
            //run the checks
            if( a_iAmount > m_iPartyGold )
            {
                //spend request too big
                return 1;
            }
            else if( a_iAmount <= 0 )
            {//spend request too small
                Debug.LogError("Attempting to spend zero or negative amount of gold - $" + a_iAmount.ToString());
                return 1;
            }
            m_iPartyGold -= a_iAmount;
            return 0; //passed all checks, return all clear
        }
    }

    public bool CheckBalance( int a_iAmount )
    {
        if (a_iAmount < m_iPartyGold)
            return true; //have enough funds
        return false;
    }
}
