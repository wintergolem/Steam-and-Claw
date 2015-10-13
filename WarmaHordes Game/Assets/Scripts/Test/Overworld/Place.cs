using UnityEngine;
using System.Collections;
/*************deprecated coded present********/    
//??? = maybe deprecated?
public class Place : MonoBehaviour
{

    #region public variables
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
    public int iRecruitAvailable = 10;     //get set should be made to prevent outside tempering
    public int iRecruitCost = 10;       //???
    public int iMaxRecruits = 10;       //???
    public string sFactionName;         //???
    public string sName;                //???
    public ParticleSystem fire;
    #endregion

    #region Private variables

    bool m_bRaided = false;
    bool m_bRecruiting = false;
    static float m_fRaidRecoveryTime = 10;  //in seconds
    static float m_fRecruitTime = 100000;       //in seconds
    float m_fTimeRaided;
    float m_fTimeRecruiting;

    #endregion
    //public Functions

    public int GetRecruit(bool bClearRecruit = false)
    {
        if( bClearRecruit )
        {
            int iTemp = iRecruitAvailable;
            iRecruitAvailable = 0;
            return iTemp;
        }
        return iRecruitAvailable;
    }

    public void TakeHostileAction()
    {
        m_bRaided = true;
        GameManager.factionManager.AffectRelationBetweenFactions(sFactionName, "Player", 0 , true);
        m_fTimeRaided = 0;
    }

    public void Recruited()
    {
        m_bRecruiting = true;
        iRecruitAvailable = 0;
        m_fTimeRecruiting = 0;
    }

    public InfoHolder SendInfoHolder()
    {//called when switching scenes, used to hold important info
        InfoHolder i = new InfoHolder();
        i.sPlaceName = sName;
        i.bRaided = m_bRaided;
        i.fTimeRaided = m_fTimeRaided;
        i.bRecruiting = m_bRecruiting;
        i.fTimeRecruiting = m_fTimeRecruiting;
        i.iRecruitAvailable = iRecruitAvailable;
        return i;
    }

    void Awake ()
    {
        InfoHolder i = new InfoHolder();
        i.sPlaceName = sName;
        if( GameManager.placeInfoHolder.RequestInfo(ref i) )
        {//info was passed
            m_bRaided = i.bRaided;
            m_fTimeRaided = i.fTimeRaided;
            m_fTimeRecruiting = i.fTimeRecruiting;
            iRecruitAvailable = i.iRecruitAvailable;
            m_bRecruiting = i.bRecruiting;
            iRecruitAvailable = i.iRecruitAvailable;
        }

    }

	void Start () {
        sFactionName = "Enemy";     //defaulting to Enemy til that system is built
	}
	
	void Update () 
    {
        //add recruits
        if (m_bRecruiting)
        {
            m_fTimeRecruiting += Time.deltaTime;
            if( m_fTimeRecruiting >= m_fRecruitTime)
            {
                iRecruitAvailable = (int)Random.Range(1, iMaxRecruits);
                m_bRecruiting = false;
                m_fTimeRecruiting = 0;
            }
        }
        //update and check Raided status (consider turning into coroutine)
        if( bRaided )
        {
            m_fTimeRaided += Time.deltaTime;
            if (m_fTimeRaided >= m_fRaidRecoveryTime)
            {
                m_bRaided = false;
                m_fTimeRaided = 0;
            }
        }
        //indicate burned
        if (bRaided)
            if(!fire.isPlaying)
                fire.Play();
        else if (fire.isPlaying)
            fire.Stop();
	}
}
