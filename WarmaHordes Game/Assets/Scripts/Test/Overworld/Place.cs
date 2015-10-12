using UnityEngine;
using System.Collections;
/*************deprecated coded present********/    
//??? = maybe deprecated?
public class Place : MonoBehaviour {

    public bool bRaided                 //bool for checking if in Raided state
    {
        get
        {
            return m_bRaided;
        }
        set
        {

        }
    }
    public int iRecruitAmount = 10;     //???
    public int iRecruitCost = 10;       //???
    public int iMaxRecruits = 10;       //???
    public string sFactionName;         //???
    public string sName;                //???
    public ParticleSystem fire;


    #region Private variables

    bool m_bRaided = false;
    RaidedCounter raidedCounter;        //RaidedCounter Class is in PlaceInfoHolder.cs
    #endregion
    //public Functions

    public int GetRecruit(bool bClearRecruit = false)
    {
        if( bClearRecruit )
        {
            int iTemp = iRecruitAmount;
            iRecruitAmount = 0;
            return iTemp;
        }
        return iRecruitAmount;
    }

    public void TakeHostileAction()
    {
        m_bRaided = true;
        GameManager.factionManager.AffectRelationBetweenFactions(sFactionName, "Player", 0 , true);
    }

    public InfoHolder SendInfoHolder()
    {//called when switching scenes, used to hold important info
        InfoHolder i = new InfoHolder();
        i.sPlaceName = sName;
        i.bRaided = m_bRaided;
        i.fTimeRaided = raidedCounter.fTimeRaided;
        return i;
    }

    void Awake ()
    {
        InfoHolder i = new InfoHolder();
        i.sPlaceName = sName;
        if( GameManager.placeInfoHolder.RequestInfo(ref i) )
        {//info was passed
            m_bRaided = i.bRaided;
            raidedCounter.fTimeRaided = i.fTimeRaided;
        }

    }

	void Start () {
        sFactionName = "Enemy";     //defaulting to Enemy til that system is built
        raidedCounter = new RaidedCounter();
	}
	
	void Update () 
    {
        //add recruits
        if (iRecruitAmount == 0)
            iRecruitAmount = (int)Random.Range(1, iMaxRecruits);
        //update and check Raided status (consider turning into coroutine)
        if( bRaided )
        {

        }
        //indicate burned
        if (bRaided)
            if(!fire.isPlaying)
                fire.Play();
        else if (fire.isPlaying)
            fire.Stop();
	}
}
